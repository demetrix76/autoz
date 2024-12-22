using autotaz.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data;
using System.Globalization;

namespace autotaz
{
    public partial class ManagerControl2 : UserControl
    {
        private Model.ATContext _context;

        private ManagerEmployeeView2[] _currentData = [];

        //private int _selectedDepartmentId = 0;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int SelectedDepartmentId { get; set; } = 0;

        //private DateTime _selectedDate = DateTime.Now;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTime SelectedDate { get; set; } = DateTime.Now;

        public DateRange DisplayPeriod
        {
            get
            {
                var begin = new DateOnly(SelectedDate.Year, SelectedDate.Month, 1);
                var end = begin.AddMonths(1);
                return new(begin, end);
            }
        }

        public ManagerControl2()
        {
            InitializeComponent();

            grid.VirtualMode = true;
            grid.AutoGenerateColumns = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.AllowUserToResizeColumns = true;
            grid.MultiSelect = false;
        }

        private void ManagerControl2_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            _context = ContextFactory.make();

            cbDepartments.DataSource = _context.Departments.OrderBy(d => d.Name).ToList();
            cbDepartments.DisplayMember = nameof(Department.Name);
            cbDepartments.ValueMember = nameof(Department.Id);

            SelectedDepartmentId = (int)cbDepartments.SelectedValue!;
            cbDepartments.DataBindings.Add(nameof(ComboBox.SelectedValue), this, nameof(SelectedDepartmentId));
            dtPeriod.DataBindings.Add(nameof(DateTimePicker.Value), this, nameof(SelectedDate));
            FetchData();
        }

        private void FetchData()
        {
            Console.WriteLine($"FetchData for Id {SelectedDepartmentId} in {SelectedDate}");
            grid.Rows.Clear();
            grid.Columns.Clear();
            grid.AutoGenerateColumns = false;
            grid.EnableHeadersVisualStyles = false;

            var lst = _context.Employees
                .OrderBy(e => e.Lastname)
                .ThenBy(e => e.Firstname)
                .Include(e => e.Assignments.Where(a => a.Since < DisplayPeriod.End).OrderBy(a => a.Since))
                .Where(e => e.Assignments.Any(a => a.DepartmentId == SelectedDepartmentId))
                .Include(e => e.Worklogs.Where(w => w.Date >= DisplayPeriod.Begin && w.Date < DisplayPeriod.End))
                .ToList();

            _currentData = lst
                .Select(e => new ManagerEmployeeView2 { Employee = e, ApplicablePeriods = applicableWorkPeriods(e, SelectedDepartmentId, DisplayPeriod).ToArray() })
                .Where(e => e.ApplicablePeriods.Any())
                .ToArray();

            grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ФИО", Frozen = true, ReadOnly = true });
            grid.Rows.Add(_currentData.Count());

            var period = DisplayPeriod;
            for (var date = period.Begin; date < period.End; date = date.AddDays(1))
            {
                var column = new DataGridViewTextBoxColumn
                {
                    HeaderText = $"{DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName(date.DayOfWeek)}\n{date.Day}",
                    Resizable = DataGridViewTriState.False,
                    Width = 48
                };
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight;
                if (DateHelpers.IsHoliday(date))
                    column.HeaderCell.Style.ForeColor = Color.Red;
                grid.Columns.Add(column);
            }
            grid.Refresh();
            grid.AutoResizeColumn(0);
        }

        private static IEnumerable<DateRange> applicableWorkPeriods(Employee employee, int departmentId, DateRange dateRange)
        {
            DateOnly? currentPeriodBegin = null;

            foreach (var assignment in employee.Assignments)
            {
                if (currentPeriodBegin is null)
                {
                    if (assignment.DepartmentId == departmentId)
                        currentPeriodBegin = assignment.Since;
                }
                else // currentPeriodBegin != null
                {
                    if (assignment.DepartmentId != departmentId)
                    {
                        yield return new DateRange(currentPeriodBegin.Value, assignment.Since).Intersect(dateRange);
                        currentPeriodBegin = null;
                    }
                }
            }

            if (currentPeriodBegin is not null)
                yield return new DateRange(currentPeriodBegin.Value, dateRange.End).Intersect(dateRange);
        }

        private void grid_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex >= _currentData.Count())
            {
                e.Value = null;
                return;
            }
            if (e.ColumnIndex == 0)
            {
                e.Value = _currentData[e.RowIndex]?.Employee?.FullName;
                return;
            }
            else
            {
                e.Value = null;
                var date = DisplayPeriod.Begin.AddDays(e.ColumnIndex - 1);
                var eview = _currentData[e.RowIndex];

                if (eview != null && eview.ActiveAt(date))
                {
                    var eid = _currentData[e.RowIndex]?.Employee?.Id;
                    var wlog = _context.Worklogs.Find(eid, date);
                    if (wlog is null || _context.Entry(wlog).State == EntityState.Deleted)
                        e.Value = null;
                    else
                        e.Value = wlog?.Hours?.ToString();
                }
            }
        }

        private void grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                var date = DisplayPeriod.Begin.AddDays(e.ColumnIndex - 1);
                var record = _currentData[e.RowIndex];
                e.CellStyle!.Alignment = DataGridViewContentAlignment.MiddleRight;
                if (DateHelpers.IsHoliday(date) || !record.ActiveAt(date))
                {
                    e.CellStyle!.BackColor = Color.LightGray;
                }
            }
        }

        private void grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                var date = DisplayPeriod.Begin.AddDays(e.ColumnIndex - 1);
                var record = _currentData[e.RowIndex];
                if (DateHelpers.IsHoliday(date) || !record.ActiveAt(date))
                {
                    e.Cancel = true;
                }
            }
        }

        private void grid_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.ColumnIndex == 0) return;
            if (e.RowIndex >= _currentData.Count()) return;

            var date = DisplayPeriod.Begin.AddDays(e.ColumnIndex - 1);
            var record = _currentData[e.RowIndex];
            if(record is null || record.Employee is null) return;

            var stringValue = e.Value?.ToString()?.Trim() ?? "";

            int numValue = 0;
            int.TryParse(stringValue, out numValue);

            numValue = Math.Min(numValue, 8);

            logWork(record.Employee.Id, date, numValue);

            //if (numValue == 0)
            //{
            //    // delete the existing record
            //    var wlog = _context.Worklogs.Find(record?.Employee?.Id, date);
            //    if (wlog != null)
            //        _context.Worklogs.Remove(wlog);
            //}
            //else
            //{
            //    var wlog = _context.Worklogs.Find(record?.Employee?.Id, date);
            //    if (wlog != null)
            //    {
            //        wlog.Hours = numValue;
            //        _context.Worklogs.Update(wlog);
            //    }
            //    else
            //    {
            //        _context.Worklogs.Add(new Worklog { Date = date, EmployeeId = record!.Employee!.Id, Hours = numValue });
            //    }
            //}
        }

        // 0 means we delete the log record
        private void logWork(int employeeId, DateOnly date, int hours)
        {
            var wlog = _context.Worklogs.Find(employeeId, date);
            if(hours == 0)
            {
                if (wlog != null)
                    _context.Worklogs.Remove(wlog);
            }
            else
            {
                if(wlog != null)
                {
                    wlog.Hours = hours;
                    _context.Worklogs.Update(wlog);
                }
                else
                {
                    _context.Worklogs.Add(new Worklog { Date = date, EmployeeId = employeeId, Hours = hours });
                }
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            _context.SaveChanges();
            grid.Refresh();
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                foreach (var cell in grid.SelectedCells.Cast<DataGridViewCell>())
                {
                    var date = DisplayPeriod.Begin.AddDays(cell.ColumnIndex - 1);
                    var record = _currentData[cell.RowIndex];
                    
                    if (record is null || record.Employee is null)
                        continue;

                    logWork(record.Employee.Id, date, 0);
                    grid.UpdateCellValue(cell.ColumnIndex, cell.RowIndex);
                }
            }
        }

        private void dtPeriod_ValueChanged(object sender, EventArgs e)
        {
            dtPeriod.DataBindings[nameof(dtPeriod.Value)]?.WriteValue();
            FetchData();
        }

        private void cbDepartments_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbDepartments.DataBindings[nameof(ComboBox.SelectedValue)].WriteValue();
            FetchData();
        }
    } // class ManagerControl2

    public class ManagerEmployeeView2
    {
        public Employee? Employee { get; set; }
        public DateRange[] ApplicablePeriods { get; set; } = [];

        public bool ActiveAt(DateOnly date)
        {
            return ApplicablePeriods.Any(wp => wp.Includes(date));
        }
    }

}
