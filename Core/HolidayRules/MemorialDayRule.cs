using System;
using Core.Classes;

namespace Core.HolidayRules;

public class MemorialDayRule : LastDayOfWeekInMonth
{
    public MemorialDayRule() : base(DayOfWeek.Monday, Month.May)
    {
    }
}