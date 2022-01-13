using System;
using Core.Classes;

namespace Core.HolidayRules;

public abstract class FixedDate : HolidayRule
{
    private readonly Month _month;
    private readonly int _day;

    protected FixedDate(Month month, int day)
    {
        _month = month;
        _day = day;
    }

    protected override DateTime DetermineDate(int year)
    {
        return new DateTime(year, (int)_month, _day);
    }
}