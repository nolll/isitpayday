namespace Core.Classes;

public class Frequency
{
    public string Id { get; }
    public string Name { get; }

    public Frequency(string id, string name)
    {
        Id = id;
        Name = name;
    }
}