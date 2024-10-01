namespace Returns;
/// <summary>
/// Error types should implement this abstract class. 
/// </summary>
public record  Fault
{
    /// <summary>
    /// Error message
    /// </summary>
    public string Message {get; }
    /// <summary>
    /// Error description
    /// </summary>
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

    /// <summary>
    /// Fault is an abstraction for error. This factory method will create type of <see cref="ReturnError"/> 
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static Fault Create(string message, string description) => new ReturnError(message, description);
    /// <summary>
    /// Fault is an abstraction for error. This factory method will create type of <see cref="Conflict"/> 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    public static Fault Conflict(string message, string? description = null) => new Conflict(message, description);
    /// <summary>
    /// Fault is an abstraction for error. This factory method will create type of <see cref="NotFound"/> 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    public static Fault NotFound(string message, string? description = null) => new NotFound(message, description);
    /// <summary>
    /// Fault is an abstraction for error. This factory method will create type of <see cref="InternalError"/> 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    public static Fault InternalError(string message, string? description = null) => new InternalError(message, description);
    /// <summary>
    /// Fault is an abstraction for error. This factory method will create type of <see cref="Unauthorized"/> 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    public static Fault Unauthorized(string message, string? description = null) => new Unauthorized(message, description);
    /// <summary>
    /// Fault is an abstraction for error. This factory method will create type of <see cref="BadRequest"/> 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    public static Fault BadRequest(string message, string? description = null) => new BadRequest(message, description);
    /// <summary>
    /// Fault is an abstraction for error. This factory method will create type of <see cref="InvalidArguments"/> 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    public static Fault InvalidArguments(string message, string? description = null) => new InvalidArguments(message, description);
}

