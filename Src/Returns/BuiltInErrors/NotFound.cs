namespace Returns;

public record NotFound : Fault
{
    public NotFound(string message, string? description = null) : base(message, description)
    {
    }
}