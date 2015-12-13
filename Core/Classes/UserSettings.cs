﻿using System;
using System.Linq;
using Core.Services;

namespace Core.Classes
{
    public class UserSettings
    {
        private const int DefaultPayDay = 25;
        private const PayDayType DefaultPayDayType = PayDayType.Monthly;
        private const string DefaultCountryCode = "SE";
        private const string DefaultTimezone = "W. Europe Standard Time";
        
        public int PayDay { get; private set; }
        public PayDayType PayDayType { get; private set; }
        public Country Country { get; private set; }
        public TimeZoneInfo TimeZone { get; private set; }

        public UserSettings(Country country, TimeZoneInfo timeZone, int payDay, PayDayType payDayType)
        {
            PayDayType = payDayType;
            Country = country;
            TimeZone = timeZone;
            PayDay = payDay;
        }

        public UserSettings(int? payDay, int? payDayType, string countryCode, string timezoneId)
        {
            PayDay = GetSelectedPayDay(payDay);
            PayDayType = GetSelectedPayDayType(payDayType);
            Country = GetCountry(countryCode);
            TimeZone = GetTimeZone(timezoneId);
        }

        private static Country GetCountry(string countryCode)
        {
            var c = countryCode ?? DefaultCountryCode;
            return CountryService.GetCountries().FirstOrDefault(o => o.Id == c);
        }

        private static TimeZoneInfo GetTimeZone(string timezoneId)
        {
            var t = timezoneId ?? DefaultTimezone;
            return TimeZoneInfo.GetSystemTimeZones().FirstOrDefault(o => o.Id == t);
        }

        private static int GetSelectedPayDay(int? payDay)
        {
            return payDay ?? DefaultPayDay;
        }

        private static PayDayType GetSelectedPayDayType(int? payDayType)
        {
            if (!payDayType.HasValue)
                return DefaultPayDayType;
            return payDayType.Value == 2 ? PayDayType.Weekly : PayDayType.Monthly;
        }
    }
}
