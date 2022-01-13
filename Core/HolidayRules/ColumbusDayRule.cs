using System;
using Core.Classes;

namespace Core.HolidayRules;

public class ColumbusDayRule : NthDayOfWeekInMonth
{
    public ColumbusDayRule() : base(2, DayOfWeek.Monday, Month.October)
    {
    }
}