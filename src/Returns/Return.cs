using Returns.Exceptions;

namespace Returns;

public readonly partial struct Return 
{
    private List<Fault>? _errors { get; }

    public readonly bool IsSuccessful { get; }
    public readonly bool IsFailure => !IsSuccessful;
    public Fault Error => IsFailure ? _errors!.First()! : throw new InvalidRequestException("Return was successful. No errors were generated.");
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