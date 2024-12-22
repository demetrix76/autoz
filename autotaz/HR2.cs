using autotaz.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autotaz
{
    public partial class HR2 : UserControl
    {
        private ATContext? _context;
        private BindingList<HR2View>? _dataView;
        public HR2()
        {
            InitializeComponent();

            grid.AutoGenerateColumns = false;
            grid.Columns.AddRange(new DataGridViewTextBoxColumn[] {
                new() { HeaderText = "ТН", DataPropertyName = "Id", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells, DefaultCellStyle = new DataGridViewCellStyle(){ Alignment = DataGridViewContentAlignment.MiddleRight } },
                new() { HeaderText = "ФИО", DataPropertyName = "FullName", AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill },
                new() { HeaderText = "Подразделение", DataPropertyName = "Department", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },
                new() { HeaderText = "Назначен/ уволен", DataPropertyName = "Since", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },
                new() { HeaderText = "З/п в месяц", DataPropertyName = "Salary", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells, DefaultCellStyle = new DataGridViewCellStyle(){ Format = "# ##0.00" } }
            });
        }

        private void HR2_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            _context = ContextFactory.make();
            fetchData();
        }

        private void fetchData()
        {
            var query = _context!.Employees
                .OrderBy(e => e.Id)
                .Include(e => e.Assignments.OrderBy(a => a.Since))
                .Include("Assignments.Department")
                .Select(e => new HR2View(e));

            _dataView = new(query.ToList());
            grid.DataSource = _dataView;
        }

        private void saveData()
        {
            _context!.SaveChanges();
            foreach (var record in _dataView!)
                record.raiseAllPropertiesChanged();
        }

        private void onNewEmployee(object sender, EventArgs e)
        {
            var newEmployee = new Employee();
            var newEmployeeForm = new EmployeeEdit("Новый сотрудник", newEmployee);
            if (DialogResult.OK == newEmployeeForm.ShowDialog())
            {
                _context!.Employees.Add(newEmployee);
                _dataView!.Add(new HR2View(newEmployee));
            }
        }

        private void onSave(object sender, EventArgs e)
        {
            saveData();
        }

        private void activateGrid(int columnIndex)
        {
            Console.WriteLine($"Activate; column = {columnIndex}");
            if (columnIndex < 2)
                onEditEmployee(this, new ());
            else
                onAssignEmployee(this, new());
        }

        private void onEditEmployee(object sender, EventArgs e)
        {
            var employeeRec = grid.CurrentRow.DataBoundItem as HR2View;
            if (employeeRec != null)
            {
                var editEmployeeForm = new EmployeeEdit($"Редактирование данных сотрудника {employeeRec.FullName}", employeeRec.DbEmployee);
                if (DialogResult.OK == editEmployeeForm.ShowDialog())
                    employeeRec.raiseAllPropertiesChanged();
            }
        }

        private void onAssignEmployee(object sender, EventArgs e)
        {
            var employeeRec = grid.CurrentRow.DataBoundItem as HR2View;
            if (employeeRec != null)
            {
                var dbEmployee = employeeRec.DbEmployee;
                var latestAssignment = dbEmployee.Assignments.LastOrDefault();

                var employeeAssignForm = new EmployeeAssign()
                {
                    Context = _context,
                    FullName = employeeRec.FullName,
                    Salary = latestAssignment?.Salary,
                    Department = latestAssignment?.Department
                };

                if (DialogResult.OK == employeeAssignForm.ShowDialog())
                {
                    var newAssignment = new Model.Assignment()
                    {
                        Department = employeeAssignForm.Department,
                        Salary = employeeAssignForm.Salary,
                        Since = DateOnly.FromDateTime(employeeAssignForm.Since)
                    };
                    dbEmployee.Assignments.Add(newAssignment);
                    employeeRec.updateAssignment();
                    employeeRec.raiseAllPropertiesChanged();
                }
            }
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            activateGrid(e.ColumnIndex);
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                activateGrid(grid.CurrentCell.ColumnIndex);
        }
    }

    public class HR2View: INotifyPropertyChanged
    {
        private Model.Employee _employee;

        private Model.Assignment? _latestAssignment;

        private static string[] _propertyNames = typeof(Employee).GetProperties().Select(p => p.Name).ToArray();

        public HR2View(Model.Employee employee)
        {
            _employee = employee;
            updateAssignment();
        }

        public int Id { get { return _employee.Id; } }
        public string FullName { get { return $"{_employee.Lastname} {_employee.Firstname} {_employee.Patronymic}"; } }
        public string? Department { get => _latestAssignment?.Department?.Name; }
        public DateOnly? Since { get => _latestAssignment?.Since; }
        public decimal? Salary { get => _latestAssignment?.Salary; }

        public Model.Employee DbEmployee { get => _employee; }

        public void updateAssignment()
        {
            _latestAssignment = _employee.Assignments.MaxBy(p => p.Since);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void raiseAllPropertiesChanged()
        {
            foreach(var propertyName in _propertyNames)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
