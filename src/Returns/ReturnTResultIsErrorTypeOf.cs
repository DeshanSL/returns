using Returns.Exceptions;

namespace Returns;


public readonly partial record struct Return<TResult>
{
    /// <summary>
    /// True if Error/Fault type is matching to TFault Type
    /// </summary>
    /// <typeparam name="TFault"></typeparam>
    /// <returns></returns>
    /// <exception cref="InvalidRequestException"></exception>
    public bool IsErrorTypeOf<TFault>() where TFault : Fault
    {
        if (!IsFailure)
        {
            throw new InvalidRequestException("Result should be error to call this method.");
        }

        if (typeof(TFault) == Error.GetType())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// Returns true if errors contain TFault Type error
    /// </summary>
    /// <typeparam name="TFault"></typeparam>
    /// <returns></returns>
    /// <exception cref="InvalidRequestException"></exception>
    public bool ErrorsContain<TFault>() where TFault : Fault
    {
        if (!IsFailure)
        {
            throw new InvalidRequestException("Result should be error to call this method.");
        }

        if (_errors!.Any(a => a.GetType() == typeof(TFault)))
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}