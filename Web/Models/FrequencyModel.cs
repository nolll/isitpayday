using JetBrains.Annotations;

namespace Web.Models;

public class FrequencyModel
{
    [UsedImplicitly]
    public string Id { get; }

    [UsedImplicitly]
    public string Name { get; }

    public FrequencyModel(string id, string name)
    {
        Id = id;
        Name = name;
    }
}