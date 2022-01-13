using Core.Classes;

namespace Tests.Common.FakeClasses;

public class CountryInTest : Country
{
    public CountryInTest(
        string id = "",
        string cultureName = "",
        string name = "") : 
        base(
            id, 
            cultureName,
            name)
    {
    }
}