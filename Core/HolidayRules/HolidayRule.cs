using System;
using System.Collections.Generic;
using Core.HolidayAdjustments;

namespace Core.HolidayRules;

public abstract class HolidayRule
{
    private readonly List<HolidayAdjustment> _adjustments = new List<HolidayAdjustment>();
    protected abstract DateTime DetermineDate(int year);

    public DateTime GetDate(int year)
    {
        return ApplyAdjustments(DetermineDate(year));
    }

    public HolidayRule Adjust(HolidayAdjustment adjustment)
    {
        _adjustments.Add(adjustment);
        return this;
    }

    private DateTime ApplyAdjustments(DateTime date)
    {
        foreach (var a in _adjustments)
        {
            date = a.AdjustDate(date);
        }
        return date;
    }
}