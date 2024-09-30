namespace Returns;

public static class FaultTypeExtensions{
    
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