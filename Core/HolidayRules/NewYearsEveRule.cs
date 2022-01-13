using Core.Classes;

namespace Core.HolidayRules;

public class NewYearsEveRule : FixedDate
{
    public NewYearsEveRule() : base(Month.December, 31)
    {
    }
}