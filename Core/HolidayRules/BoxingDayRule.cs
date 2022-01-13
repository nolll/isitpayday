using Core.Classes;

namespace Core.HolidayRules;

public class BoxingDayRule : FixedDate
{
    public BoxingDayRule() : base(Month.December, 26)
    {
    }
}