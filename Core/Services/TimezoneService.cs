using System;
using System.Collections.Generic;
using System.Linq;
using Core.Exceptions;
using TimeZoneConverter;

namespace Core.Services;

public static class TimezoneService
{
    private static IEnumerable<TimeZoneInfo> WindowsTimezones => TimeZoneInfo.GetSystemTimeZones();

    public static TimeZoneInfo GetTimezone(string id)
    {
        var timezone = GetWindowsTimezone(id);
        if (timezone != null)
            return timezone;

        timezone = GetIanaTimezone(id);
        if (timezone != null)
            return timezone;

        throw new TimezoneNotFoundException(id);
    }

    private static TimeZoneInfo GetWindowsTimezone(string id)
    {
        return WindowsTimezones.FirstOrDefault(o => o.Id == id);
    }

    private static TimeZoneInfo GetIanaTimezone(string ianaId)
    {
        try
        {
            var windowsId = TZConvert.IanaToWindows(ianaId);
            return GetWindowsTimezone(windowsId);
        }
        catch (InvalidTimeZoneException)
        {
            return null;
        }
    }
}