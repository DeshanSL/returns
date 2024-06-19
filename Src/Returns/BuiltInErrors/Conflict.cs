namespace Returns;

public class Conflict : Fault
{
    public Conflict(string message, string? description = null) : base(message, description)
    {
    }
}