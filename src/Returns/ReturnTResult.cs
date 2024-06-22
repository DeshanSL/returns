using Returns.Exceptions;

namespace Returns;

public readonly partial struct Return<TResult>  
{
    /// <summary>
    /// Holds the value returned if operation is successful. 
    /// </summary>
    /// <value></value>
    private readonly TResult? _value { get; }
    /// <summary>
    /// Holds Fault/Error if operation was failed. 
    /// </summary>
    /// <value></value>
    private readonly List<Fault>? _errors { get; }

    /// <summary>
    /// can be used to access returned value if operation was successful.
    /// </summary>
    /// <returns cref="TResult">Value returned.</returns>
    /// <exception cref="InvalidRequestException">When try to read value with failure result.</exception>
    public TResult? Value => IsSuccessful ? _value
    : throw new InvalidRequestException("Value can not be read when result is failure.");

    /// <summary>
    /// Returns first error of the list. 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidRequestException"> When try to read error but result is successful. </exception>
    public Fault Error => IsFailure ? _errors!.First()
    : throw new InvalidRequestException("Return was successful. No errors were generated.");
    /// <summary>
    /// Returns read only list of errors. 
    /// </summary>
    /// <returns></returns>
    public IReadOnlyList<Fault> Errors => IsFailure ? _errors!.AsReadOnly()
    : throw new InvalidRequestException("Return was successful. No errors were generated.");
    /// <summary>
    /// True when result is success. 
    /// </summary>
    /// <value></value>
    public readonly bool IsSuccessful { get; }
    /// <summary>
    /// True when result is failed or error. 
    /// </summary>
    public readonly bool IsFailure => !IsSuccessful;
    /// <summary>
    /// Success path with no errors.
    /// </summary>
    /// <param name="value"></param>
    private Return(TResult value)
    {
        _value = value;
        _errors = null;
        IsSuccessful = true;
    }

    /// <summary>
    /// Error path with one error 
    /// </summary>
    /// <param name="error"></param>
    private Return(Fault error)
    {
        _value = default(TResult);
        _errors = error is null ? [ReturnError.Create("Return was not successful.")] : [error];
        IsSuccessful = false;
    }

    /// <summary>
    /// Error path with list of errors 
    /// </summary>
    /// <param name="errors"></param>
    private Return(List<Fault> errors)
    {
        if (errors is null || errors.Count == 0)
        {
            throw new ReturnsValueGenerationException("At least one error should be in the error list.");
        }
        _value = default(TResult);
        _errors = errors;
        IsSuccessful = false;
    }
    public Return()
    {
        throw new InvalidConstructorCallException("Parameterless constructor should not be called.");
    }

}