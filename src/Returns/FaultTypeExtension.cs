namespace Returns;

public static class FaultTypeExtensions{
    /// <summary>
    /// Returns true if Error/Fault is the Type of <see cref="TFault"/>
    /// </summary>
    /// <typeparam name="TFault">Type to the Fault</typeparam>
    /// <param name="fault"></param>
    /// <returns></returns>
    public static bool Is<TFault>(this Fault fault) where TFault : Fault
    {
        if (typeof(TFault) == fault.GetType())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// Returns true if one of the errors is TFault Type
    /// </summary>
    /// <typeparam name="TFault"></typeparam>
    /// <param name="faults"></param>
    /// <returns></returns>
    public static bool ContainsErrorType<TFault>(this IReadOnlyList<Fault> faults) where TFault : Fault
    {
        if (faults.Any(a => a.GetType() == typeof(TFault)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}