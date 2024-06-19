namespace Returns;
/// <summary>
/// Error types should implemet this abstract class. 
/// </summary>
public abstract  class Fault
{
    public string Message {get; }
    public string? Description {get; }

    protected Fault(string message, string? description = null)
    {
        Message = message;
        Description = description;
    }

    public static Fault Create(string message) => new DefaultError(message);
    public static Fault Create(string message, string description) => new DefaultError(message, description);
}

