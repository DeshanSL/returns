namespace Returns.Exceptions;

public sealed class InvalidRequestException : Exception
{
    public InvalidRequestException(string message): base(message)
    {
        
    }
}