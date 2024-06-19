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

    private Return(Fault fault)
    {
        _errors = [fault];
        IsSuccessful = false;
    }

    private Return(bool isSuccessful)
    {
        _errors = null;
        IsSuccessful = isSuccessful;
        if(!isSuccessful)
        {
            _errors = [DefaultError.Create("Operation was not successful.")];
        }
    }

}