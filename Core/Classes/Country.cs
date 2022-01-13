namespace Core.Classes;

public class Country
{
    public string Id { get; }
    public string CultureName { get; }
    public string Name { get; }

    public Country(string id, string cultureName, string name)
    {
        Id = id;
        CultureName = cultureName;
        Name = name;
    }
}