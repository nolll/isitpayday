using Core.Classes;

namespace Core.HolidayRules;

public class VeteransDayRule : FixedDate
{
    public VeteransDayRule() : base(Month.November, 11)
    {
    }
}