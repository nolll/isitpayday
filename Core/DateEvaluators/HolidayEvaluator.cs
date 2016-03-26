﻿using System;
using System.Collections.Generic;
using System.Linq;
using Core.Classes;
using Core.DateEvaluators.CountrySpecific;
using Core.HolidayRules;

namespace Core.DateEvaluators
{
    public abstract class HolidayEvaluator
    {
        protected abstract List<IHolidayRule> HolidayRules { get; }

        public static bool IsHoliday(Country country, DateTime userTime)
        {
            return GetEvaluator(country).Evaluate(userTime);
        }

        private bool Evaluate(DateTime userTime)
        {
            return GetHolidays(userTime.Year).Contains(userTime.Date);
        }

        private List<DateTime> GetHolidays(int year)
        {
            return HolidayRules.Select(o => o.GetDate(year)).ToList();
        }

        private static HolidayEvaluator GetEvaluator(Country country)
        {
            if(country.Id == "SE")
                return new SwedishHolidayEvaluator();
            return new DefaultHolidayEvaluator();
        }
    }
}