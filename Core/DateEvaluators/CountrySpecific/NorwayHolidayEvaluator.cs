using System.Collections.Generic;
using Core.HolidayRules;

namespace Core.DateEvaluators.CountrySpecific;

public class NorwayHolidayEvaluator : HolidayEvaluator
{
    public override string CountryCode => "NO";

    protected override IEnumerable<HolidayRule> HolidayRules => new List<HolidayRule>
    {
        new NewYearsDayRule(),
        new MaundyThursdayRule(),
        new GoodFridayRule(),
        new EasterMondayRule(),
        new InternationalWorkersDayRule(),
        new AscensionDayRule(),
        new NationalDayNorwayRule(),
        new WhitMondayRule(),
        new ChristmasEveRule(),
        new ChristmasDayRule(),
        new BoxingDayRule(),
        new NewYearsEveRule()
    };
}