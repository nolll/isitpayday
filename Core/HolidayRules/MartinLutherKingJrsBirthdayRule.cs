using System;
using Core.Classes;

namespace Core.HolidayRules;

public class MartinLutherKingJrsBirthdayRule : NthDayOfWeekInMonth
{
    public MartinLutherKingJrsBirthdayRule() : base(3, DayOfWeek.Monday, Month.January)
    {
    }
}