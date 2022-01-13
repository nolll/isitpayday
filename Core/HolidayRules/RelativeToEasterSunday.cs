using System;

namespace Core.HolidayRules;

public abstract class RelativeToEasterSunday : HolidayRule
{
    private readonly int _diffInDays;

    protected RelativeToEasterSunday(int diffInDays)
    {
        _diffInDays = diffInDays;
    }

    protected override DateTime DetermineDate(int year)
    {
        return GetEasterSunday(year).AddDays(_diffInDays);
    }

    // The algorithm was found here: http://stackoverflow.com/questions/26022233/calculate-the-date-of-easter-sunday
    private static DateTime GetEasterSunday(int year)
    {
        int a = year % 19,
            b = year / 100,
            c = year % 100,
            d = b / 4,
            e = b % 4,
            g = (8 * b + 13) / 25,
            h = (19 * a + b - d - g + 15) % 30,
            j = c / 4,
            k = c % 4,
            m = (a + 11 * h) / 319,
            r = (2 * e + 2 * j - k - h + m + 32) % 7,
            month = (h - m + r + 90) / 25,
            day = (h - m + r + month + 19) % 32;

        return new DateTime(year, month, day);
    }
}