using System.Collections.Generic;
using Core.Classes;

namespace Core.Services;

public static class FrequencyService
{
    public static IEnumerable<Frequency> GetFrequencies()
    {
        return new List<Frequency>
        {
            new Frequency("monthly", "Monthly"),
            new Frequency("weekly", "Weekly")
        };
    }
}