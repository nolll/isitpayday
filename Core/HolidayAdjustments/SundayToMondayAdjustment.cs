using System;

namespace Core.HolidayAdjustments;

public class SundayToMondayAdjustment : HolidayAdjustment
{
    public override DateTime AdjustDate(DateTime date)
    {
        if (date.DayOfWeek == DayOfWeek.Sunday)
            return date.AddDays(1);
        return date;
    }
}