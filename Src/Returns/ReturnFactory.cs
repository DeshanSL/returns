namespace Returns;

public readonly partial struct Return
{
    public static Return Success() => new Return(true);
    public static Return Failure() => new Return(false);

    public static Return Failure(Fault fault) => new Return(fault);
    public static Return Failure(List<Fault> faults) => new Return(faults);
}