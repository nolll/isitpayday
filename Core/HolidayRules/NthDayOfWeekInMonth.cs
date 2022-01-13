using System;
using Core.Classes;

namespace Core.HolidayRules;

public abstract class NthDayOfWeekInMonth : HolidayRule
{
    private readonly int _nth;
    private readonly DayOfWeek _dayOfWeek;
    private readonly Month _month;

    protected NthDayOfWeekInMonth(int nth, DayOfWeek dayOfWeek, Month month)
    {
        _nth = nth;
        _dayOfWeek = dayOfWeek;
        _month = month;
    }

    protected override DateTime DetermineDate(int year)
    {
        return GetNthDayOfWeekInMonth(year);
    }

    private DateTime GetNthDayOfWeekInMonth(int year)
    {
        return GetFirstDayOfWeekInMonth(year).AddDays(7 * (_nth - 1));
    }

    private DateTime GetFirstDayOfWeekInMonth(int year)
    {
        var date = new DateTime(year, (int)_month, 1);
        while (date.DayOfWeek != _dayOfWeek)
        {
            date = date.AddDays(1);
        }
        return date;
    }
}