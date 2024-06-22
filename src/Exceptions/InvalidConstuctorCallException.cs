namespace Returns.Exceptions;

internal sealed class InvalidConstructorCallException : Exception{
    internal InvalidConstructorCallException(string message) : base(message)
    {
        
    }
}