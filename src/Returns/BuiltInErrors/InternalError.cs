namespace Returns;

public record InternalError : Fault
{
    public InternalError(string message, string? description = null) : base(message, description)
    {
    }
}
