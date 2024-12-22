using autotaz.Model;
using Microsoft.EntityFrameworkCore;

namespace autotaz
{
    public class SalaryCalculator
    {
        private ATContext context;
        private int employeeId;
        private DateRange monthPeriod;

        public int WorkingDaysInMonth { get; set; } = 0;
        public int WorkingHoursInMonth { get; set; } = 0;

        public SalaryCalculator(int employeeId, DateOnly month)
        {
            this.employeeId = employeeId;
            this.monthPeriod = DateRange.MakeMonth(month);
            context = ContextFactory.make();

            WorkingDaysInMonth = monthPeriod.Where(d => !DateHelpers.IsHoliday(d)).Count();
            WorkingHoursInMonth = WorkingDaysInMonth * 8;
        }

        public WorkSlice[] GetWorkSlices()
        {
            var slices = getWorkSlices().ToArray();
            foreach(var slice in slices )
            {
                var hoursWorked = context.Worklogs
                    .Where(w => w.EmployeeId == employeeId && w.Date >= slice.Period.Begin && w.Date < slice.Period.End)
                    .Sum(w => w.Hours)
                    .GetValueOrDefault();
                slice.HoursWorked = hoursWorked;
            }
            return slices;
        }

        private IEnumerable<WorkSlice> getWorkSlices()
        {
            var assignments = context.Assignments
                .Where(a => a.EmployeeId == employeeId && a.Since < monthPeriod.End)
                .OrderBy(a => a.Since)
                .Include(a => a.Department);

            WorkSlice? currentSlice = null;

            void beginNewSliceIfNeeded(Assignment assignment)
            {
                if (assignment.DepartmentId is not null)
                {
                    currentSlice = new()
                    {
                        Period = new(assignment.Since, assignment.Since),
                        DepartmentId = assignment.DepartmentId.Value,
                        DepartmentName = assignment.Department!.Name,
                        Salary = assignment.Salary!.Value,
                        HourlyRate = assignment.Salary!.Value / WorkingHoursInMonth
                    };
                }
            }
                
            foreach(var assignment in assignments)
            {
                if(currentSlice is null)
                {
                    if (assignment.DepartmentId is not null)
                    {
                        beginNewSliceIfNeeded (assignment);
                    }
                }
                else // currentSlice is not null
                {
                    currentSlice.Terminate(assignment.Since, monthPeriod);
                    if(!currentSlice.Period.Empty)
                        yield return currentSlice;
                    currentSlice = null;
                    beginNewSliceIfNeeded(assignment);
                }
            }

            if(currentSlice is not null)
            {
                currentSlice.Terminate(monthPeriod.End, monthPeriod);
                if (!currentSlice.Period.Empty)
                    yield return currentSlice;
            }
        }

        public class WorkSlice
        {
            private decimal hourlyRate;
            private int hoursWorked;
            private decimal paymentForPeriod;

            public DateRange Period {  get; set; }
            public int DepartmentId { get; set; }
            public string DepartmentName { get; set; } = string.Empty;
            public decimal Salary {  get; set; }

            public decimal HourlyRate { get => hourlyRate; set{ hourlyRate = value; RecalcPayment(); } }
            public int HoursWorked { get => hoursWorked; set {hoursWorked = value; RecalcPayment(); } }
            public decimal PaymentForPeriod {  get => paymentForPeriod; set { paymentForPeriod = value; } }

            public void Terminate(DateOnly date, DateRange monthRange)
            {
                Period = new DateRange(Period.Begin, date).Intersect(monthRange);
            }

            public void RecalcPayment()
            {
                paymentForPeriod = hourlyRate * hoursWorked;
            }
        }


    }
}
