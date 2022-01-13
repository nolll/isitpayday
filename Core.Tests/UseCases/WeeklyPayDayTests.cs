using Core.Classes;
using Core.UseCases;
using NUnit.Framework;
using Tests.Common;

namespace Core.Tests.UseCases;

public class WeeklyPayDayTests
{
    [Test]
    public void Execute_TodayIsPayDay_IsTrue()
    {
        var request = new WeeklyPayday.Request((int)Weekday.Friday, "SE", TestData.Timezones.Utc, TestData.Dates.UnblockedFriday);

        var sut = GetSut();
        var result = sut.Execute(request);

        Assert.IsTrue(result.IsPayDay);
    }

    [Test]
    public void Execute_TodayIsNotPayDay_IsFalse()
    {
        var request = new WeeklyPayday.Request((int)Weekday.Thursday, "SE", TestData.Timezones.Utc, TestData.Dates.UnblockedFriday);

        var sut = GetSut();
        var result = sut.Execute(request);

        Assert.IsFalse(result.IsPayDay);
    }

    [Test]
    public void Execute_TomorrowIsChristmasEve_TodayIsPayday()
    {
        var request = new WeeklyPayday.Request((int)Weekday.Thursday, "SE", TestData.Timezones.Utc, TestData.Dates.DayBeforeChristmasEve);

        var sut = GetSut();
        var result = sut.Execute(request);

        Assert.IsTrue(result.IsPayDay);
    }

    private WeeklyPayday GetSut()
    {
        return new WeeklyPayday();
    }
}