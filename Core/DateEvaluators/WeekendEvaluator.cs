using System;
using Core.WeekendRules;

namespace Core.DateEvaluators;

public class WeekendEvaluator
{
    public static bool IsWeekend(DateTime userTime)
    {
        return WeekendRule.IsWeekend(userTime);
    }
}