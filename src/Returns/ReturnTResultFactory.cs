namespace Returns;

public readonly partial struct Return<TResult>
{ 
    /// <summary>
    /// Notifies success results.
    /// </summary>
    /// <param name="result"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Return<TResult> Success(TResult result) => new Return<TResult>(result);
    /// <summary>
    ///  Notifies failure with one fault 
    /// </summary>
    /// <param name="fault"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Return<TResult> Failure(Fault fault) => new Return<TResult>(fault);
    /// <summary>
    ///  Notifies failure with Multiple faults 
    /// </summary>
    /// <param name="faults"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Return<TResult> Failure(List<Fault> faults) => new Return<TResult>(faults);
    /// <summary>
    /// Returns Default error type. 
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Return<TResult> Failure() => ReturnError.Create("Undifined.Error");

}