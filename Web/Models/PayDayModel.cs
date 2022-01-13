using System;
using Core.UseCases.Shared;
using JetBrains.Annotations;

namespace Web.Models;

public class PayDayModel
{
    [UsedImplicitly]
    public bool IsPayDay { get; }

    [UsedImplicitly]
    public string NextPayDay { get; }

    [UsedImplicitly]
    public DateTime LocalTime { get; }

    public PayDayModel(PaydayResult showPayDayResult)
    {
        IsPayDay = showPayDayResult.IsPayDay;
        NextPayDay = showPayDayResult.NextPayDay.ToString("yyyy-MM-dd");
        LocalTime = showPayDayResult.LocalTime;
    }
}