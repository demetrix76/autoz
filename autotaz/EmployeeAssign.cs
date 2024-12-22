using Microsoft.EntityFrameworkCore;

namespace autotaz
{
    public partial class EmployeeAssign : Form
    {
        public Model.ATContext? Context { get; set; }
        public decimal? Salary { get; set; } = 0;
        public Model.Department? Department { get; set; }
        public DateTime Since { get; set; } = DateTime.Now;

        public String FullName { get; set; } = string.Empty;
        public EmployeeAssign()
        {
            InitializeComponent();
        }
        private void EmployeeAssign_Load(object sender, EventArgs e)
        {
            Text = $"Назначить сотрудника {FullName}";
            Context!.Departments.Load();
            cbDepartments.DataSource = Context.Departments.Local.ToList();
            cbDepartments.DisplayMember = "Name";
            cbDepartments.ValueMember = "Id";

            txSalary.DataBindings.Add("Text", this, nameof(Salary), true, DataSourceUpdateMode.OnPropertyChanged, null, "#0.00");
            cbDepartments.DataBindings.Add(nameof(ComboBox.SelectedItem), this, nameof(Department), true, DataSourceUpdateMode.OnPropertyChanged);
            dpDate.DataBindings.Add("Value", this, "Since");
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (Department == null || Salary == 0)
                MessageBox.Show(this, "Неверные значения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                DialogResult = DialogResult.OK;
        }

        private void btFire_Click(object sender, EventArgs e)
        {
            Department = null;
            Salary = null;
            DialogResult = DialogResult.OK;
        }

        private void cbDepartments_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbDepartments.DataBindings[nameof(ComboBox.SelectedItem)].WriteValue();
        }
    }
}
