using JetBrains.Annotations;

namespace Web.Models;

public class TimezoneModel
{
    [UsedImplicitly]
    public string Id { get; }

    [UsedImplicitly]
    public string Name { get; }

    public TimezoneModel(string id, string name)
    {
        Id = id;
        Name = name;
    }
}