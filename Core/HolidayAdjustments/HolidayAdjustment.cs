using System;

namespace Core.HolidayAdjustments;

public abstract class HolidayAdjustment
{
    public abstract DateTime AdjustDate(DateTime date);
}

public static class Adjust
{
    public static HolidayAdjustment SaturdayToFriday = new SaturdayToFridayAdjustment();
    public static HolidayAdjustment SundayToMonday = new SundayToMondayAdjustment();
}