namespace Returns;

public readonly partial record struct Return
{
    /// <summary>
    /// When result is success 
    /// </summary>
    /// <returns></returns>
    public static Return Success() => new Return(true);
    /// <summary>
    /// Allows to return <see cref="ReturnError"/> type with default error message 
    /// </summary>
    /// <returns></returns>
    public static Return Failure() => new Return(false);
    /// <summary>
    /// Failure result with custom error type 
    /// </summary>
    /// <param name="fault"></param>
    /// <returns></returns>
    public static Return Failure(Fault fault) => new Return(fault);
    /// <summary>
    /// Failure result with list of error types
    /// </summary>
    /// <param name="faults"></param>
    /// <returns></returns>
    public static Return Failure(List<Fault> faults) => new Return(faults);

}