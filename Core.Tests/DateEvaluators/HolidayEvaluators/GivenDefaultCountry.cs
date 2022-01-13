using NUnit.Framework;

namespace Core.Tests.DateEvaluators.HolidayEvaluators;

public class GivenDefaultCountry : Arrange
{
    [Test]
    public void NewYearsDayIsNotHoliday() => Assert.IsFalse(IsHoliday("2016-01-01"));

    [Test]
    public void EpiphanyIsNotHoliday() => Assert.IsFalse(IsHoliday("2016-01-06"));

    [Test]
    public void GoodFridayIsNotHoliday() => Assert.IsFalse(IsHoliday("2016-03-25"));

    [Test]
    public void EasterMondayIsNotHoliday() => Assert.IsFalse(IsHoliday("2016-03-28"));

    [Test]
    public void AscensionDayIsNotHoliday() => Assert.IsFalse(IsHoliday("2016-05-05"));

    [Test]
    public void ChristmasEveIsNotHoliday() => Assert.IsFalse(IsHoliday("2016-12-24"));

    [Test]
    public void ChristmasDayIsNotHoliday() => Assert.IsFalse(IsHoliday("2016-12-25"));

    [Test]
    public void BoxingDayIsNotHoliday() => Assert.IsFalse(IsHoliday("2016-12-26"));

    [Test]
    public void NewYearsEveIsNotHoliday() => Assert.IsFalse(IsHoliday("2016-12-31"));

    [Test]
    public void AnyOtherDayIsNotHoliday() => Assert.IsFalse(IsHoliday("2016-01-02"));
}