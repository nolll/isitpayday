using System;
using Core.Classes;

namespace Core.HolidayRules;

public class PresidentsDayRule : NthDayOfWeekInMonth
{
    public PresidentsDayRule() : base(3, DayOfWeek.Monday, Month.February)
    {
    }
}