namespace Core.Exceptions;

public class CountryNotFoundException : NotFoundException
{
    public CountryNotFoundException(string countryCode)
        : base($"Country not found: {countryCode}")
    {
    }
}