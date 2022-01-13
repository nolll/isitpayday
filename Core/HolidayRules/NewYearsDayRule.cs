using Core.Classes;

namespace Core.HolidayRules;

public class NewYearsDayRule : FixedDate
{
    public NewYearsDayRule() : base(Month.January, 1)
    {
    }
}