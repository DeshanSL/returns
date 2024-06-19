namespace Returns;

public class NotFound : Fault
{
    public NotFound(string message, string? description = null) : base(message, description)
    {
    }
}