namespace Returns;

public record ReturnError : Fault
{
    public ReturnError(string message, string? description = null) : base(message, description)
    {
    }
}
