﻿using System;
using Core.Classes;

namespace Core.DateEvaluators
{
    public class MonthlyPayDayEvaluator
    {
        private readonly Country _country;
        private readonly DateTime _utcTime;
        private readonly TimeZoneInfo _timezone;
        private readonly int _payDay;

        public MonthlyPayDayEvaluator(Country country, DateTime utcTime, TimeZoneInfo timezone, int payDay)
        {
            _country = country;
            _utcTime = utcTime;
            _timezone = timezone;
            _payDay = payDay;
        }

        private DateTime LocalTime => TimeZoneInfo.ConvertTime(_utcTime, _timezone);
        public bool IsPayDay => LocalTime.Date == NextPayDay;

        public DateTime NextPayDay
        {
            get
            {
                var payDayDate = GetNextPayDate(LocalTime);
                while (BlockedEvaluator.IsBlocked(_country, payDayDate))
                {
                    payDayDate = payDayDate.AddDays(-1);
                }
                return payDayDate.Date;
            }
        }

        private DateTime GetNextPayDate(DateTime localTime)
        {
            var payDay = AdjustPayDayForShortMonths(localTime);
            while (localTime.Day != payDay)
            {
                localTime = localTime.AddDays(1);
            }
            return localTime;
        }

        private int AdjustPayDayForShortMonths(DateTime localTime)
        {
            var payDay = _payDay;
            while (!IsMonthLongEnough(localTime, payDay))
            {
                payDay--;
            }
            return payDay;
        }

        private bool IsMonthLongEnough(DateTime time, int payDay)
        {
            try
            {
                var foo = new DateTime(time.Year, time.Month, payDay);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}