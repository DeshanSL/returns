
namespace Returns;
public readonly partial record struct Return
{
    /// <summary>
    /// Actions to take after the result without any return
    /// </summary>
    /// <param name="onSuccess"></param>
    /// <param name="onFailure"></param>
    public void AfterSuccessOrError(Action onSuccess, Action<List<Fault>> onFailure)
    {
        if (IsSuccessful)
        {
            onSuccess();
        }
        if (IsFailure)
        {
            onFailure(Errors.ToList());
        }
    }
    /// <summary>
    /// Actions to take async without return type.
    /// </summary>
    /// <param name="onSuccessAsync"></param>
    /// <param name="onFailureAsync"></param>
    /// <returns></returns>
    public async Task AfterSuccessOrErrorAsync(Func<Task> onSuccessAsync, Func<List<Fault>, Task> onFailureAsync)
    {
        if (IsSuccessful)
        {
            await onSuccessAsync();
        }
        if (IsFailure)
        {
            await onFailureAsync(Errors.ToList());
        }
    }

    /// <summary>
    /// Actions to take then it returns success or failure.
    /// </summary>
    /// <param name="onSuccess"></param>
    /// <param name="onFailure"></param>
    /// <returns></returns>
    public Return AfterSuccessOrError(Func<Return> onSuccess, Func<List<Fault>, Return> onFailure)
    {
        if (IsFailure)
        {
            return onFailure(Errors.ToList());
        }
        else
        {
            return onSuccess();
        }
    }
    /// <summary>
    /// Actions to take then it return success or failure async
    /// </summary>
    /// <param name="onSuccessAsync"></param>
    /// <param name="onFailureAsync"></param>
    /// <returns></returns>
    public async Task<Return> AfterSuccessOrErrorAsync(Func<Task<Return>> onSuccessAsync, Func<List<Fault>, Task<Return>> onFailureAsync)
    {
        if (IsFailure)
        {
            return await onFailureAsync(Errors.ToList());
        }
        else
        {
            return await onSuccessAsync();
        }
    }

    public Return<TNextValue> AfterSuccess<TNextValue>(Func<TNextValue> onSuccess, Func<List<Fault>, TNextValue>? onFailure = null)
    {
        if (IsSuccessful)
        {
            return onSuccess();
        }

        if (onFailure is not null)
        {
            if (IsFailure)
                return onFailure(Errors.ToList());
        }

        return Errors.ToList();
    }

    public async Task<Return<TNextValue>> AfterSuccessAsync<TNextValue>(Func<Task<TNextValue>> onSuccess, Func<List<Fault>, Task<TNextValue>>? onFailure = null)
    {
        if (IsSuccessful)
        {
            return await onSuccess();
        }

        if (onFailure is not null)
        {
            if (IsFailure)
                return await onFailure(Errors.ToList());
        }

        return Errors.ToList();
    }


}