using System.Collections.Generic;
using Core.HolidayRules;

namespace Core.DateEvaluators.CountrySpecific;

public class DenmarkHolidayEvaluator : HolidayEvaluator
{
    public override string CountryCode => "DK";

    protected override IEnumerable<HolidayRule> HolidayRules => new List<HolidayRule>
    {
        new NewYearsDayRule(),
        new MaundyThursdayRule(),
        new GoodFridayRule(),
        new EasterMondayRule(),
        new PrayerDayRule(),
        new AscensionDayRule(),
        new WhitMondayRule(),
        new NationalDayDenmarkRule(),
        new ChristmasEveRule(),
        new ChristmasDayRule(),
        new BoxingDayRule(),
        new NewYearsEveRule()
    };
}