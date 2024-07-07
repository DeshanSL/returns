namespace Returns;
public readonly partial record struct Return
{
    public void Match(Action onSuccess, Action<List<Fault>> onFailure)
    {
        if (IsSuccessful)
        {
            onSuccess();
        }
        else
        {
            onFailure(Errors.ToList());
        }
    }

    public void MatchFirst(Action onSuccess, Action<Fault> onFailure)
    {
        if (IsSuccessful)
        {
            onSuccess();
        }
        else
        {
            onFailure(Error);
        }
    }
    public TNextValue MatchFirst<TNextValue>(Func<TNextValue> onSuccess, Func<Fault, TNextValue> onFailure)
    {
        if (IsSuccessful)
        {
            return onSuccess();
        }
        else
        {
            return onFailure(Error);
        }
    }

    public TNextValue Match<TNextValue>(Func<TNextValue> onSuccess, Func<List<Fault>, TNextValue> onFailure)
    {
        if (IsSuccessful)
        {
            return onSuccess();
        }
        else
        {
            return onFailure(Errors.ToList());
        }
    }
}