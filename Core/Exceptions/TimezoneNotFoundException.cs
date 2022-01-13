namespace Core.Exceptions;

public class TimezoneNotFoundException : NotFoundException
{
    public TimezoneNotFoundException(string id)
        : base($"Timezone not found: {id}")
    {
    }
}