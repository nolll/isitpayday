using System;
using Core.Classes;

namespace Core.HolidayRules;

public class MidsummersEveRule : FirstDayOfWeekFrom
{
    public MidsummersEveRule() : base(DayOfWeek.Friday, Month.June, 19)
    {
    }
}