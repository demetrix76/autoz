using autotaz.Model;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace autotaz
{
    public partial class EmployeeControl : UserControl
    {
        static readonly string html = @"
<!DOCTYPE html>
<html>
    <head>
        <style type=""text/css"">
            body { font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; }
            h2 { text-align: center;}
            table {border-collapse: collapse; margin-bottom: 1em;}
            td {border: 1pt solid black; padding: 0pt 4pt;}
            th {border: 1pt solid black; padding: 0pt 4pt; border-bottom: 4pt solid black;}
        </style>
    </head>
    <body>
        <h1>ПАО ""Автозавод""</h1>
        <h2>Расчётный лист сотрудника</h2>
        <table>
            <tr>
                <td>ФИО</td>
                <td>Иванов Иван Иванович</td>
            </tr>
            <tr>
                <td>Расчётный период</td>
                <td>Март 2024</td>
            </tr>
            <tr>
                <td>Рабочих дней в периоде</td>
                <td>20</td>
            </tr>
            <tr>
                <td>Рабочих часов в периоде</td>
                <td>160</td>
            </tr>
        </table>

        <table>
            <tr>
                <th>Н.пп</th>
                <th>Период</th>
                <th>Подразделение</th>
                <th>З/п в месяц</th>
                <th>Часовая ставка</th>
                <th>Отработано часов</th>
                <th>Начислено за период</th>
            </tr>
            <tr>
                <td align=""center"">1</td>
                <td>1 мар 2024-14 мар 2024</td>
                <td>Цех антигравитационных двигателей</td>
                <td>60000.00</td>
                <td>375</td>
                <td>40</td>
                <td>15000.00</td>
            </tr>
            <tr>
                <td align=""center"">2</td>
                <td>1 мар 2024-14 мар 2024</td>
                <td>Сборочный цех</td>
                <td>80000.00</td>
                <td>500</td>
                <td>40</td>
                <td>20000.00</td>
            </tr>
            <tr style=""border-top:4pt solid black"">
                <td colspan=""5"">Итого</td>
                <td>80</td>
                <td>35000.00</td>
            </tr>
        </table>
    </body>
</html>
";

        private ATContext? _context;
        public EmployeeControl()
        {
            InitializeComponent();
        }

        private void EmployeeControl_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            _context = ContextFactory.make();

            var employeeList = _context.Employees.AsNoTracking().OrderBy(e => e.Lastname).ThenBy(e => e.Firstname).ToList();
            cbEmployee.DataSource = employeeList;
            cbEmployee.DisplayMember = "FullName";
            cbEmployee.ValueMember = "Id";
            Console.WriteLine($"Selected id: {cbEmployee.SelectedValue}");

            assignmentHistory.DbContext = _context;
            assignmentHistory.EmployeeId = cbEmployee.SelectedValue as int?;

            showHistoryFor(cbEmployee.SelectedValue as int?);
            showPayrollFor(cbEmployee.SelectedItem as Employee, DateOnly.FromDateTime(dtPeriod.Value));
            //setPayrollContent(html);

        }

        private void setPayrollContent(string content)
        {
            payView.EnsureCoreWebView2Async().ContinueWith(
                _ => payView.NavigateToString(content),
                TaskContinuationOptions.ExecuteSynchronously
            );
        }

        private void showHistoryFor(int? employeeId)
        {
            assignmentHistory.EmployeeId = employeeId;
        }

        private void showPayrollFor(Employee? employee, DateOnly month)
        {
            var contentBuilder = new StringBuilder();
            try
            {
                if (employee is null) return;

                var calculator = new SalaryCalculator(employee.Id, month);

                contentBuilder.Append(string.Format(PayrollTemplates.HeaderTemplate,
                    employee.FullName,
                    $"{month:MMMM yyyy}",
                    calculator.WorkingDaysInMonth,
                    calculator.WorkingHoursInMonth
                ));

                int currentNum = 1;
                int totalHours = 0;
                decimal totalPayment = 0;

                foreach(var slice in calculator.GetWorkSlices())
                {
                    contentBuilder.Append(string.Format(PayrollTemplates.WorkRowTemplate,
                        currentNum++,
                        $"{slice.Period.Begin:d MMM yyyy}-{slice.Period.Last:d MMM yyyy}",
                        slice.DepartmentName,
                        slice.Salary,
                        slice.HourlyRate,
                        slice.HoursWorked,
                        slice.PaymentForPeriod
                    ));
                    totalHours += slice.HoursWorked;
                    totalPayment += slice.PaymentForPeriod;
                }

                contentBuilder.Append(string.Format(PayrollTemplates.TotalRowTemplate, totalHours, totalPayment));

                contentBuilder.Append(PayrollTemplates.FooterTemplate);
            }
            finally
            {
                setPayrollContent(contentBuilder.ToString());
            }
        }

        private void cbEmployee_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selId = cbEmployee.SelectedValue as int?;
            Console.WriteLine($"SelectionChangeCommitted to {selId}");
            showHistoryFor(cbEmployee.SelectedValue as int?);
            showPayrollFor(cbEmployee.SelectedItem as Employee, DateOnly.FromDateTime(dtPeriod.Value));
        }

        private void dtPeriod_ValueChanged(object sender, EventArgs e)
        {
            showPayrollFor(cbEmployee.SelectedItem as Employee, DateOnly.FromDateTime(dtPeriod.Value));
        }
    }
}
