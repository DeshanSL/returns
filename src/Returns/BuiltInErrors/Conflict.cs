namespace Returns;

public record Conflict : Fault
{
    public Conflict(string message, string? description = null) : base(message, description)
    {
    }
}