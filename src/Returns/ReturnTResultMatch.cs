namespace Returns;
public readonly partial record struct Return<TResult>
{

    public void Match(Action<TResult> onSuccess, Action<List<Fault>> onFailure)
    {
        if (IsSuccessful)
        {
            onSuccess(Value);
        }
        else
        {
            onFailure(Errors.ToList());
        }
    }

    public void MatchFirst(Action<TResult> onSuccess, Action<Fault> onFailure)
    {
        if (IsSuccessful)
        {
            onSuccess(Value);
        }
        else
        {
            onFailure(Error);
        }
    }
    public TNextValue MatchFirst<TNextValue>(Func<TResult, TNextValue> onSuccess, Func<Fault, TNextValue> onFailure)
    {
        if (IsSuccessful)
        {
            return onSuccess(Value);
        }
        else
        {
            return onFailure(Error);
        }
    }

    public TNextValue Match<TNextValue>(Func<TResult, TNextValue> onSuccess, Func<List<Fault>, TNextValue> onFailure)
    {
        if (IsSuccessful)
        {
            return onSuccess(Value);
        }
        else
        {
            return onFailure(Errors.ToList());
        }
    }

}
