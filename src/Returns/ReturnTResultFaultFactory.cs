namespace Returns;

public readonly partial record struct Return<TResult>
{
    public static Fault Conflict(string message, string? description = null) => new Conflict(message, description);
    public static Fault NotFound(string message, string? description = null) => new NotFound(message, description);
    public static Fault InternalError(string message, string? description = null) => new InternalError(message, description);
    public static Fault Unauthorized(string message, string? description = null) => new Unauthorized(message, description);
    public static Fault BadRequest(string message, string? description = null) => new BadRequest(message, description);
    public static Fault InvalidArguments(string message, string? description = null) => new InvalidArguments(message, description);
}