namespace Returns.Exceptions;

internal sealed class InvalidRequestException : Exception
{
    internal InvalidRequestException(string message) : base(message)
    {
    }
}