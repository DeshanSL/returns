namespace Returns;
public readonly partial record struct Return
{
    /// <summary>
    /// Executes the provided action based on whether the result is successful or not.
    /// </summary>
    /// <param name="onSuccess">The action to execute if the result is successful.</param>
    /// <param name="onFailure">The action to execute if the result is a failure, providing the list of errors.</param>
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

    /// <summary>
    /// Executes the provided action based on whether the result is successful or not.
    /// </summary>
    /// <param name="onSuccess">The action to execute if the result is successful.</param>
    /// <param name="onFailure">The action to execute if the result is a failure, providing the first error.</param>
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

    /// <summary>
    /// Executes the provided function based on whether the result is successful or not and returns the result of the function.
    /// </summary>
    /// <typeparam name="TNextValue">The type of the value returned by the functions.</typeparam>
    /// <param name="onSuccess">The function to execute if the result is successful, returning a value of type <typeparamref name="TNextValue"/>.</param>
    /// <param name="onFailure">The function to execute if the result is a failure, providing the first error and returning a value of type <typeparamref name="TNextValue"/>.</param>
    /// <returns>The value returned by either the onSuccess or onFailure function.</returns>
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

    /// <summary>
    /// Executes the provided function based on whether the result is successful or not and returns the result of the function.
    /// </summary>
    /// <typeparam name="TNextValue">The type of the value returned by the functions.</typeparam>
    /// <param name="onSuccess">The function to execute if the result is successful, returning a value of type <typeparamref name="TNextValue"/>.</param>
    /// <param name="onFailure">The function to execute if the result is a failure, providing the list of errors and returning a value of type <typeparamref name="TNextValue"/>.</param>
    /// <returns>The value returned by either the onSuccess or onFailure function.</returns>
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