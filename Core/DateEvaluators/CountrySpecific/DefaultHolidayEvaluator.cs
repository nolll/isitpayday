using System.Collections.Generic;
using Core.HolidayRules;

namespace Core.DateEvaluators.CountrySpecific;

public class DefaultHolidayEvaluator : HolidayEvaluator
{
    public override string CountryCode => null;

    protected override IEnumerable<HolidayRule> HolidayRules => new List<HolidayRule>
    {
    };
}