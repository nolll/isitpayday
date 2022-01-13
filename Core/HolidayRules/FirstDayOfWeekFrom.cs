using System;
using Core.Classes;

namespace Core.HolidayRules;

public abstract class FirstDayOfWeekFrom : HolidayRule
{
    private readonly DayOfWeek _dayOfWeek;
    private readonly Month _month;
    private readonly int _day;

    protected FirstDayOfWeekFrom(DayOfWeek dayOfWeek, Month month, int day)
    {
        _dayOfWeek = dayOfWeek;
        _month = month;
        _day = day;
    }

    protected override DateTime DetermineDate(int year)
    {
        var date = new DateTime(year, (int)_month, _day);
        while (date.DayOfWeek != _dayOfWeek)
            date = date.AddDays(1);
        return date;
    }
}