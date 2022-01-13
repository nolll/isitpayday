using System;
using Core.Classes;

namespace Core.HolidayRules;

public class ThanksgivingDayRule : NthDayOfWeekInMonth
{
    public ThanksgivingDayRule() : base(4, DayOfWeek.Thursday, Month.November)
    {
    }
}