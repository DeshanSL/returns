
namespace Returns;
public readonly partial record struct Return<TResult>
{

    public async Task MatchAsync(Func<TResult, Task> onSuccess, Func<List<Fault>, Task> onFailure)
    {
        if (IsSuccessful)
        {
            await onSuccess(Value);
        }
        else
        {
            await onFailure(Errors.ToList());
        }
    }

    public async Task MatchFirstAsync(Func<TResult, Task> onSuccess, Func<Fault, Task> onFailure)
    {
        if (IsSuccessful)
        {
            await onSuccess(Value);
        }
        else
        {
            await onFailure(Error);
        }
    }
    public async Task<TNextValue> MatchFirstAsync<TNextValue>(Func<TResult,Task<TNextValue>> onSuccess, Func<Fault, Task<TNextValue>> onFailure)
    {
        if (IsSuccessful)
        {
            return await onSuccess(Value);
        }
        else
        {
            return await onFailure(Error);
        }
    }

    public async Task<TNextValue> MatchAsync<TNextValue>(Func<TResult, Task<TNextValue>> onSuccess, Func<List<Fault>, Task<TNextValue>> onFailure)
    {
        if (IsSuccessful)
        {
            return await onSuccess(Value);
        }
        else
        {
            return await onFailure(Errors.ToList());
        }
    }
}
