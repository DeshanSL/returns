namespace Returns;

public record InvalidArguments : Fault
{
    public InvalidArguments(string message, string? description = null) : base(message, description)
    {
    }
}
