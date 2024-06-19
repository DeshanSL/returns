namespace Returns;

public readonly partial struct Return<TResult>
{
    /// <summary>
    /// Converts TResult to Returns<TResult>  
    /// </summary>
    /// <param name="result">Result value when operation is success</param>
    /// <typeparam name="TResult">Type of the result</typeparam>
    public static implicit operator Return<TResult>(TResult? result) => new Return<TResult>(result);
    /// <summary>
    /// Allows to return any implementation of fault abstration.
    /// </summary>
    /// <param name="fault"></param>
    /// <typeparam name="TResult"></typeparam>
    public static implicit operator Return<TResult>(Fault fault) => new Return<TResult>(fault);
    /// <summary>
    /// Allows to return list of errors at once. 
    /// </summary>
    /// <param name="faults"></param>
    /// <typeparam name="TResult"></typeparam>
    public static implicit operator Return<TResult>(List<Fault> faults) => new Return<TResult>(faults);

    

}