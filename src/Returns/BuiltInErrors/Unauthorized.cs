namespace Returns;

public record Unauthorized : Fault
{
    public Unauthorized(string message, string? description = null) : base(message, description)
    {
    }
}
public record BadRequest : Fault
{
    public BadRequest(string message, string? description = null) : base(message, description)
    {
    }
}
