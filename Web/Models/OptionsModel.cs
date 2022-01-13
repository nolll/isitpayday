using System.Collections.Generic;
using System.Linq;
using Core.UseCases;
using JetBrains.Annotations;

namespace Web.Models;

public class OptionsModel
{
    [UsedImplicitly]
    public IList<CountryModel> Countries { get; }

    [UsedImplicitly]
    public IList<TimezoneModel> Timezones { get; }

    [UsedImplicitly]
    public IList<FrequencyModel> Frequencies { get; }

    public OptionsModel(Options.Result optionsResult)
    {
        Countries = optionsResult.CountryOptions.Select(o => new CountryModel(o.Id, o.Name)).ToList();
        Timezones = optionsResult.TimeZoneOptions.Select(o => new TimezoneModel(o.Id, o.DisplayName)).ToList();
        Frequencies = optionsResult.FrequencyOptions.Select(o => new FrequencyModel(o.Id, o.Name)).ToList();
    }
}