using System;
using Core.Classes;
using Core.DateEvaluators;
using NUnit.Framework;
using Tests.Common.FakeClasses;

namespace Core.Tests.DateEvaluators.HolidayEvaluators;

public class Arrange
{
    private Country _country;
    protected virtual string CountryCode => "";
    protected virtual string CultureName => "";

    [SetUp]
    public void Setup()
    {
        _country = new CountryInTest(CountryCode, CultureName);
    }

    protected bool IsHoliday(string date)
    {
        var evaluator = HolidayEvaluator.Create(_country);
        return evaluator.IsHoliday(DateTime.Parse(date));
    }
}