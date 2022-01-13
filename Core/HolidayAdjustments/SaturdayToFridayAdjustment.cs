using System;

namespace Core.HolidayAdjustments;

public class SaturdayToFridayAdjustment : HolidayAdjustment
{
    public override DateTime AdjustDate(DateTime date)
    {
        if (date.DayOfWeek == DayOfWeek.Saturday)
            return date.AddDays(-1);
        return date;
    }
}