namespace autotaz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ctx = ContextFactory.make();

            var qry = from employee in ctx.Employees
                      select new { id = employee.Id, name = $"{employee.Lastname} {employee.Firstname} {employee.Patronymic ?? ""}" };

            var lst = qry.ToList();

            Console.WriteLine(qry);
        }

        private void tabsMain_Selected(object sender, TabControlEventArgs e)
        {
            Console.WriteLine("Tab selected");
        }

        private void tabsMain_Selecting(object sender, TabControlCancelEventArgs e)
        {
            Console.WriteLine("Selecting");
        }
    }
}
