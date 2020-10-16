using System;
using System.Collections.Generic;

namespace DataClassses
{
    public class RecurringTask
    {
        public int Id { get; set; }
        public RecurringType Recurring { get; set; }
        public DateTime RecurringDate { get; set; }

        public int[] MonthDays;
        public DaysOfWeek[] WeekDays;
        public List<DateTime> skipDates;
    }
}
