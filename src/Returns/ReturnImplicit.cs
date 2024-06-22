namespace Returns;

public readonly partial struct Return
{
    
    /// <summary>
    /// Allows to return any implementation of fault abstration.
    /// </summary>
    /// <param name="fault"></param>
    /// <typeparam name="TResult"></typeparam>
    public static implicit operator Return(Fault fault) => new Return(fault);
    /// <summary>
    /// Allows to return list of errors at once. 
    /// </summary>
    /// <param name="faults"></param>
    /// <typeparam name="TResult"></typeparam>
    public static implicit operator Return(List<Fault> faults) => new Return(faults);

}