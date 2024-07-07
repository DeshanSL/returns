namespace Returns;
public readonly partial record struct Return
{
    public async Task MatchAsync(Func<Task> onSuccess, Func<List<Fault>, Task> onFailure)
    {
        if (IsSuccessful)
        {
            await onSuccess();
        }
        else
        {
            await onFailure(Errors.ToList());
        }
    }

    public async Task MatchFirstAsync(Func<Task> onSuccess, Func<Fault, Task> onFailure)
    {
        if (IsSuccessful)
        {
            await onSuccess();
        }
        else
        {
            await onFailure(Error);
        }
    }
    public async Task<TNextValue> MatchFirstAsync<TNextValue>(Func<Task<TNextValue>> onSuccess, Func<Fault, Task<TNextValue>> onFailure)
    {
        if (IsSuccessful)
        {
            return await onSuccess();
        }
        else
        {
            return await onFailure(Error);
        }
    }

    public async Task<TNextValue> MatchAsync<TNextValue>(Func<Task<TNextValue>> onSuccess, Func<List<Fault>, Task<TNextValue>> onFailure)
    {
        if (IsSuccessful)
        {
            return await onSuccess();
        }
        else
        {
            return await onFailure(Errors.ToList());
        }
    }

}
