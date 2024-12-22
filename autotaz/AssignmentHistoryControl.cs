using autotaz.Model;
using Microsoft.EntityFrameworkCore;

namespace autotaz
{
    public partial class AssignmentHistoryControl : UserControl
    {
        private int? _employeeId;
        public ATContext? DbContext { get; set; }
        public int? EmployeeId { get => _employeeId; set { _employeeId = value; refreshData(); } }
        public AssignmentHistoryControl()
        {
            InitializeComponent();

            grid.Columns.AddRange(new DataGridViewTextBoxColumn[] {
                new() { HeaderText = "Дата", DataPropertyName = nameof(Model.Assignment.Since), AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },
                new() { HeaderText = "Назначение", DataPropertyName = "HistoryRecord", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
                new() { HeaderText = "З/п в месяц", DataPropertyName = "Salary", AutoSizeMode= DataGridViewAutoSizeColumnMode.AllCells, DefaultCellStyle = new DataGridViewCellStyle(){ Format = "# ##0.00" } },
            });
            grid.AutoGenerateColumns = false;
            grid.RowHeadersVisible = false;
        }

        private void refreshData()
        {
            if (DbContext is null || _employeeId is null)
            {
                grid.DataSource = null;
                return;
            }

            grid.DataSource = DbContext.Assignments.Where(a => a.Employee.Id == _employeeId)
                .Include(a => a.Department)
                .OrderBy(a => a.Since)
                .ToList();
        }
    }
}
