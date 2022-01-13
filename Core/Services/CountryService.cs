using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Core.Classes;
using Core.DateEvaluators;
using Core.Exceptions;

namespace Core.Services;

public static class CountryService
{
    public static IEnumerable<Country> GetCountries()
    {
        return HolidayEvaluator.Evaluators.Select(o => CreateCountry(o.Key)).OrderBy(o => o.Name);
    }

    public static Country GetCountry(string countryCode)
    {
        try
        {
            return GetCountries().First(o => o.Id == countryCode);
        }
        catch (Exception)
        {
            throw new CountryNotFoundException(countryCode);
        }
    }

    private static Country CreateCountry(string name)
    {
        var region = new RegionInfo(name);
        return new Country(region.TwoLetterISORegionName, name, region.DisplayName);
    }
}