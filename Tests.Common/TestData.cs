using System;

namespace Tests.Common;

public static class TestData
{
    public static class Dates
    {
        public static DateTime UnblockedFriday = new DateTime(2015, 12, 18, 12, 0, 0, DateTimeKind.Utc);
        public static DateTime DayBeforeChristmasEve = new DateTime(2015, 12, 23, 12, 0, 0, DateTimeKind.Utc);
        public static DateTime LeapYearFeb29 = new DateTime(2016, 2, 29, 12, 0, 0, DateTimeKind.Utc);
    }

    public static class Timezones
    {
        public const string Utc = "UTC";
        public const string WindowsWesternEurope = "W. Europe Standard Time";
        public const string IanaEuropeStockholm = "Europe/Stockholm";
        public const string Invalid = "Not a Timezone Id";
    }
}