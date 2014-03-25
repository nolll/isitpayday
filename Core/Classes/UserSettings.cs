﻿using System;

namespace Core.Classes
{
    public class UserSettings
    {
        public Country Country { get; private set; }
        public TimeZoneInfo TimeZone { get; private set; }
        public int PayDay { get; private set; }
        public PayDayType PayDayType { get; private set; }

        public UserSettings(Country country, TimeZoneInfo timeZone, int payDay, PayDayType payDayType)
        {
            PayDayType = payDayType;
            Country = country;
            TimeZone = timeZone;
            PayDay = payDay;
        }
    }
}
