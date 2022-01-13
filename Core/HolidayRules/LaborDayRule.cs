using System;
using Core.Classes;

namespace Core.HolidayRules;

public class LaborDayRule : NthDayOfWeekInMonth
{
    public LaborDayRule() : base(1, DayOfWeek.Monday, Month.September)
    {
    }
}