namespace Returns;
/// <summary>
/// Error types should implemet this abstract class. 
/// </summary>
public record  Fault
{
    public string Message {get; }
    public string? Description {get; }

    protected Fault(string message, string? description = null)
    {
        Message = message;
        Description = description;
    }

    /// <summary>
    /// Fault is an abstraction for error. This factory method will create type of <see cref="ReturnError"/> 
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static Fault Create(string message) => new ReturnError(message);
    public static Fault Create(string message, string description) => new ReturnError(message, description);

    public static Fault Conflict(string message, string? description = null) => new Conflict(message, description);
    public static Fault NotFound(string message, string? description = null) => new NotFound(message, description);
    public static Fault InternalError(string message, string? description = null) => new InternalError(message, description);
}

