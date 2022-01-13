using Core.Classes;

namespace Core.HolidayRules;

public class ChristmasEveRule : FixedDate
{
    public ChristmasEveRule() : base(Month.December, 24)
    {
    }
}