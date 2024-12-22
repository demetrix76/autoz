using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autotaz
{
    // NOTE: semi-open range [Begin, End)
    public struct DateRange():
        IEnumerable<DateOnly>
    {
        public DateRange(DateOnly begin, DateOnly end): this()
        {
            Begin = begin;
            End = end;
        }

        public DateOnly Begin { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly End { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public DateOnly Last { get => End.AddDays(-1); }

        public void Deconstruct(out DateOnly begin, out DateOnly end)
        {
            begin = Begin;
            end = End;
        }

        public bool Empty {  get => End <= Begin; }

        public DateRange Intersect(DateRange other)
        {
            var newBegin = Begin < other.Begin ? other.Begin : Begin;
            var newEnd = End > other.End ? other.End : End;

            if(newEnd < newBegin)
                newEnd = newBegin;

            return new(newBegin, newEnd);            
        }

        public bool Includes(DateOnly date)
        {
            return Begin <= date && date < End;
        }

        public static DateRange MakeMonth(DateOnly date)
        {
            var begin = new DateOnly(date.Year, date.Month, 1);
            var end = begin.AddMonths(1);
            return new(begin, end);
        }

        public IEnumerator<DateOnly> GetEnumerator()
        {
            for(var date = Begin; date < End; date = date.AddDays(1))
                yield return date;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (var date = Begin; date < End; date = date.AddDays(1))
                yield return date;
        }
    }

    public static class DateHelpers
    {
        public static bool IsHoliday(DateOnly date)
        {
            return date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday;
        }
    }

}
