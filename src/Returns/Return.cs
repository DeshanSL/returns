using Returns.Exceptions;

namespace Returns;

public readonly partial record struct Return 
{
    private List<Fault>? _errors { get; }
    /// <summary>
    /// true if return is successful.
    /// </summary>
    /// <value></value>
    public readonly bool IsSuccessful { get; }
    /// <summary>
    /// true if return is not successful. 
    /// </summary>
    public readonly bool IsFailure => !IsSuccessful;
    /// <summary>
    /// Returns error or first error of the list. 
    /// </summary>
    /// <returns></returns>
    public Fault Error => IsFailure ? _errors!.First() 
    : throw new InvalidRequestException("Return was successful. No errors were generated.");
    /// <summary>
    /// Returns error list as readonly. 
    /// </summary>
    /// <returns></returns>
     public IReadOnlyList<Fault> Errors => IsFailure ? _errors!.AsReadOnly()
    : throw new InvalidRequestException("Return was successful. No errors were generated.");
 
    private Return(List<Fault> faults)
    {
        if(faults is null || faults.Count <= 0)
            throw new ReturnsValueGenerationException("List of errors should contain at least one error.");
        _errors = faults;
        IsSuccessful = false;
    }
    /// <summary>
    /// Sets IsSuccess to false and assign the error passed. 
    /// </summary>
    /// <param name="fault"></param>
    private Return(Fault fault)
    {
        _errors = [fault];
        IsSuccessful = false;
    }
    /// <summary>
    /// Creates successful return if true and else create error return with <see cref="ReturnError"/> type 
    /// </summary>
    /// <param name="isSuccessful">true if successful.</param>
    private Return(bool isSuccessful)
    {
        _errors = null;
        IsSuccessful = isSuccessful;
        if(!isSuccessful)
        {
            _errors = [ReturnError.Create("Operation was not successful.")];
        }
    }
    /// <summary>
    /// Throwing <see cref="InvalidConstructorCallException"/> 
    /// </summary>
    public Return()
    {
        throw new InvalidConstructorCallException("Parameterless constructor should not be called.");
    }

}