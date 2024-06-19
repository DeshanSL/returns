namespace Returns;

public class DefaultError : Fault
{
    public DefaultError(string message, string? description = null) : base(message, description)
    {
    }
}