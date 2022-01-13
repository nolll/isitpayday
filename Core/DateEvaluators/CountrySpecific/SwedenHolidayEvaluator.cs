using System.Collections.Generic;
using Core.HolidayRules;

namespace Core.DateEvaluators.CountrySpecific;

public class SwedenHolidayEvaluator : HolidayEvaluator
{
    public override string CountryCode => "SE";

    protected override IEnumerable<HolidayRule> HolidayRules => new List<HolidayRule>
    {
        new NewYearsDayRule(),
        new EpiphanyRule(),
        new GoodFridayRule(),
        new EasterMondayRule(),
        new InternationalWorkersDayRule(),
        new AscensionDayRule(),
        new MidsummersEveRule(),
        new NationalDaySwedenRule(),
        new ChristmasEveRule(),
        new ChristmasDayRule(),
        new BoxingDayRule(),
        new NewYearsEveRule()
    };
}