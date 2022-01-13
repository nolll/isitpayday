using System;

namespace Core.UseCases.Shared;

public class PaydayResult
{
    public bool IsPayDay { get; }
    public DateTime NextPayDay { get; }
    public DateTime LocalTime { get; }

    public PaydayResult(bool isPayDay, DateTime nextPayDay, DateTime localTime)
    {
        IsPayDay = isPayDay;
        NextPayDay = nextPayDay;
        LocalTime = localTime;
    }
}