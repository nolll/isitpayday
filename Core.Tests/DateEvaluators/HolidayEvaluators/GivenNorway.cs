using NUnit.Framework;

namespace Core.Tests.DateEvaluators.HolidayEvaluators;

public class GivenNorway : Arrange
{
    protected override string CountryCode => "NO";
    protected override string CultureName => "nb-NO";

    [TestCase("2014-01-01")]
    [TestCase("2015-01-01")]
    [TestCase("2016-01-01")]
    public void NewYearsDayIsHoliday(string date) => Assert.IsTrue(IsHoliday(date));

    [TestCase("2014-04-17")]
    [TestCase("2015-04-02")]
    [TestCase("2016-03-24")]
    public void MaundyThursdayIsHoliday(string date) => Assert.IsTrue(IsHoliday(date));

    [TestCase("2014-04-18")]
    [TestCase("2015-04-03")]
    [TestCase("2016-03-25")]
    public void GoodFridayIsHoliday(string date) => Assert.IsTrue(IsHoliday(date));

    [TestCase("2014-04-21")]
    [TestCase("2015-04-06")]
    [TestCase("2016-03-28")]
    public void EasterMondayIsHoliday(string date) => Assert.IsTrue(IsHoliday(date));

    [TestCase("2014-05-01")]
    [TestCase("2015-05-01")]
    [TestCase("2016-05-01")]
    public void InternationalWorkersDayIsHoliday(string date) => Assert.IsTrue(IsHoliday(date));

    [TestCase("2014-05-29")]
    [TestCase("2015-05-14")]
    [TestCase("2016-05-05")]
    public void AscensionDayIsHoliday(string date) => Assert.IsTrue(IsHoliday(date));

    [TestCase("2014-05-17")]
    [TestCase("2015-05-17")]
    [TestCase("2016-05-17")]
    public void NationalDayIsHoliday(string date) => Assert.IsTrue(IsHoliday(date));

    [TestCase("2014-06-09")]
    [TestCase("2015-05-25")]
    [TestCase("2016-05-16")]
    public void WhitMondayIsHoliday(string date) => Assert.IsTrue(IsHoliday(date));

    [TestCase("2014-12-24")]
    [TestCase("2015-12-24")]
    [TestCase("2016-12-24")]
    public void ChristmasEveIsHoliday(string date) => Assert.IsTrue(IsHoliday(date));

    [TestCase("2014-12-25")]
    [TestCase("2015-12-25")]
    [TestCase("2016-12-25")]
    public void ChristmasDayIsHoliday(string date) => Assert.IsTrue(IsHoliday(date));

    [TestCase("2014-12-26")]
    [TestCase("2015-12-26")]
    [TestCase("2016-12-26")]
    public void BoxingDayIsHoliday(string date) => Assert.IsTrue(IsHoliday(date));

    [TestCase("2014-12-31")]
    [TestCase("2015-12-31")]
    [TestCase("2016-12-31")]
    public void NewYearsEveIsHoliday(string date) => Assert.IsTrue(IsHoliday(date));
}