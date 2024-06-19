namespace Returns;

public readonly partial struct Return
{
    public static implicit operator Return(Fault fault) => new Return(fault);
}