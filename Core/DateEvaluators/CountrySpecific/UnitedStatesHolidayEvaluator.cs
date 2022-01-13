using System.Collections.Generic;
using Core.HolidayAdjustments;
using Core.HolidayRules;

namespace Core.DateEvaluators.CountrySpecific;

public class UnitedStatesHolidayEvaluator : HolidayEvaluator
{
    public override string CountryCode => "US";

    protected override IEnumerable<HolidayRule> HolidayRules => new List<HolidayRule>
    {
        new NewYearsDayRule().Adjust(Adjust.SundayToMonday),
        new MartinLutherKingJrsBirthdayRule(),
        new PresidentsDayRule(),
        new MemorialDayRule(),
        new NationalDayUnitedStatesRule(),
        new LaborDayRule(),
        new ColumbusDayRule(),
        new VeteransDayRule().Adjust(Adjust.SaturdayToFriday).Adjust(Adjust.SundayToMonday),
        new ThanksgivingDayRule(),
        new ChristmasDayRule().Adjust(Adjust.SundayToMonday)
    };
}