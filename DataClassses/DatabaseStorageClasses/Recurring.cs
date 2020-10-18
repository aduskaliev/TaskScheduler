using System;
using System.Collections.Generic;

namespace SharedClasses
{
    public class RecurringTask
    {
        public int Id { get; set; }
        public RecurringType Recurring { get; set; }
        public DateTime RecurringDate { get; set; }

        public int[] MonthDays { get; set; }
        public DaysOfWeek[] WeekDays { get; set; }
        public List<DateTime> SkipDates { get; set; }
    }
}
