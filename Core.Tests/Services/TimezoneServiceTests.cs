using Core.Exceptions;
using Core.Services;
using NUnit.Framework;
using Tests.Common;

namespace Core.Tests.Services;

public class TimezoneServiceTests
{
    [Test]
    public void GetTimezone_WindowsTimezoneId_ReturnsTimezone()
    {
        var timezone = TimezoneService.GetTimezone(TestData.Timezones.WindowsWesternEurope);

        Assert.AreEqual(TestData.Timezones.WindowsWesternEurope, timezone.Id);
    }

    [Test]
    public void GetTimezone_IanaTimezoneId_ReturnTimezone()
    {
        var timezone = TimezoneService.GetTimezone(TestData.Timezones.IanaEuropeStockholm);

        Assert.AreEqual(TestData.Timezones.WindowsWesternEurope, timezone.Id);
    }

    [Test]
    public void GetTimezone_InvalidTimezoneId_ThrowsException()
    {
        Assert.Throws<TimezoneNotFoundException>(() => TimezoneService.GetTimezone(TestData.Timezones.Invalid));
    }
}