using System;
using Core.Classes;
using Core.DateEvaluators;  
using NUnit.Framework;
using Tests.Common.FakeClasses;

namespace Core.Tests.DateEvaluators;

public class BlockedEvaluatorTests
{
    private readonly Country _defaultCountry = new CountryInTest();
    private readonly Country _sweden = new CountryInTest(CountryCode.Sweden, CultureCode.Sweden);

    [Test]
    public void IsBlocked_WithWeekDayThatIsNotExcluded_ReturnsFalse()
    {
        var notBlockedDate = new DateTime(2015, 1, 2);

        var result = new BlockedEvaluator(_defaultCountry).IsBlocked(notBlockedDate);

        Assert.IsFalse(result);
    }

    [Test]
    public void IsBlocked_WithWeekDayThatIsHoliday_ReturnsTrue()   
    {
        var excludedDate = new DateTime(2015, 1, 1);

        var result = new BlockedEvaluator(_sweden).IsBlocked(excludedDate);

        Assert.IsTrue(result);
    }

    [Test]
    public void IsBlocked_WithWeekendDayThatIsNotExcluded_ReturnsTrue()
    {
        var weekendDate = new DateTime(2015, 1, 3);

        var result = new BlockedEvaluator(_defaultCountry).IsBlocked(weekendDate);

        Assert.IsTrue(result);
    }

    [Test]
    public void IsBlocked_WithWeekendDayThatIsExcluded_ReturnsTrue()
    {
        var blockedWeekendDate = new DateTime(2015, 6, 6);

        var result = new BlockedEvaluator(_defaultCountry).IsBlocked(blockedWeekendDate);

        Assert.IsTrue(result);
    }
}