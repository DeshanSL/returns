
using Returns.Exceptions;

namespace Returns;

public readonly partial record struct Return
{
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