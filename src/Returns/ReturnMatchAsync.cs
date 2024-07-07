namespace Returns;
public readonly partial record struct Return
{
    /// <summary>
    /// Asynchronously executes the provided function based on whether the result is successful or not.
    /// </summary>
    /// <param name="onSuccess">The asynchronous function to execute if the result is successful.</param>
    /// <param name="onFailure">The asynchronous function to execute if the result is a failure, providing the list of errors.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
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

    /// <summary>
    /// Asynchronously executes the provided function based on whether the result is successful or not.
    /// </summary>
    /// <param name="onSuccess">The asynchronous function to execute if the result is successful.</param>
    /// <param name="onFailure">The asynchronous function to execute if the result is a failure, providing the first error.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
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

    /// <summary>
    /// Asynchronously executes the provided function based on whether the result is successful or not and returns the result of the function.
    /// </summary>
    /// <typeparam name="TNextValue">The type of the value returned by the functions.</typeparam>
    /// <param name="onSuccess">The asynchronous function to execute if the result is successful, returning a value of type <typeparamref name="TNextValue"/>.</param>
    /// <param name="onFailure">The asynchronous function to execute if the result is a failure, providing the first error and returning a value of type <typeparamref name="TNextValue"/>.</param>
    /// <returns>A task representing the asynchronous operation and containing the value returned by either the onSuccess or onFailure function.</returns>
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

    /// <summary>
    /// Asynchronously executes the provided function based on whether the result is successful or not and returns the result of the function.
    /// </summary>
    /// <typeparam name="TNextValue">The type of the value returned by the functions.</typeparam>
    /// <param name="onSuccess">The asynchronous function to execute if the result is successful, returning a value of type <typeparamref name="TNextValue"/>.</param>
    /// <param name="onFailure">The asynchronous function to execute if the result is a failure, providing the list of errors and returning a value of type <typeparamref name="TNextValue"/>.</param>
    /// <returns>A task representing the asynchronous operation and containing the value returned by either the onSuccess or onFailure function.</returns>
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
