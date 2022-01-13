using NUnit.Framework;

namespace Core.Tests.DateEvaluators.HolidayEvaluators;

public class GivenUnitedStates : Arrange
{
    protected override string CountryCode => "US";
    protected override string CultureName => "en-US";

    [TestCase("2014-01-01")]
    [TestCase("2015-01-01")]
    [TestCase("2016-01-01")]
    [TestCase("2017-01-02")]
    [TestCase("2018-01-01")]
    public void NewYearsDayIsHoliday(string date) => Assert.IsTrue(IsHoliday(date));

    [TestCase("2014-01-20")]
    [TestCase("2015-01-19")]
    [TestCase("2016-01-18")]
    [TestCase("2017-01-16")]
    [TestCase("2018-01-15")]
    public void MartinLutherKingJrsBirthdayIsHoliday(string date) => Assert.IsTrue(IsHoliday(date));

    [TestCase("2014-02-17")]
    [TestCase("2015-02-16")]
    [TestCase("2016-02-15")]
    [TestCase("2017-02-20")]
    [TestCase("2018-02-19")]
    public void PresidentsDayIsHoliday(string date) => Assert.IsTrue(IsHoliday(date));

    [TestCase("2014-05-26")]
    [TestCase("2015-05-25")]
    [TestCase("2016-05-30")]
    [TestCase("2017-05-29")]
    [TestCase("2018-05-28")]
    public void MemorialDayIsHoliday(string date) => Assert.IsTrue(IsHoliday(date));

    [TestCase("2014-07-04")]
    [TestCase("2015-07-04")]
    [TestCase("2016-07-04")]
    [TestCase("2017-07-04")]
    [TestCase("2018-07-04")]
    public void IndependenceDayIsHoliday(string date) => Assert.IsTrue(IsHoliday(date));

    [TestCase("2014-09-01")]
    [TestCase("2015-09-07")]
    [TestCase("2016-09-05")]
    [TestCase("2017-09-04")]
    [TestCase("2018-09-03")]
    public void LaborDayIsHoliday(string date) => Assert.IsTrue(IsHoliday(date));

    [TestCase("2014-10-13")]
    [TestCase("2015-10-12")]
    [TestCase("2016-10-10")]
    [TestCase("2017-10-09")]
    [TestCase("2018-10-08")]
    public void ColumbusDayIsHoliday(string date) => Assert.IsTrue(IsHoliday(date));

    [TestCase("2014-11-11")]
    [TestCase("2015-11-11")]
    [TestCase("2016-11-11")]
    [TestCase("2017-11-10")]
    [TestCase("2018-11-12")]
    public void VeteransDayIsHoliday(string date) => Assert.IsTrue(IsHoliday(date));

    [TestCase("2014-11-27")]
    [TestCase("2015-11-26")]
    [TestCase("2016-11-24")]
    [TestCase("2017-11-23")]
    [TestCase("2018-11-22")]
    public void ThanksgivingDayIsHoliday(string date) => Assert.IsTrue(IsHoliday(date));

    [TestCase("2014-12-25")]
    [TestCase("2015-12-25")]
    [TestCase("2016-12-26")]
    [TestCase("2017-12-25")]
    [TestCase("2018-12-25")]
    public void ChristmasDayIsHoliday(string date) => Assert.IsTrue(IsHoliday(date));
}