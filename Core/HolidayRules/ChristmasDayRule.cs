using Core.Classes;

namespace Core.HolidayRules;

public class ChristmasDayRule : FixedDate
{
    public ChristmasDayRule() : base(Month.December, 25)
    {
    }
}