namespace CartAPI.Service.Services.Base
{
    /// <summary>
    /// IService
    /// </summary>
    /// <typeparam name="TParameter">The type of the parameter.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IService<TParameter, TResult>
    {
        /// <summary>
        /// Executes the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>Execution result</returns>
        TResult Execute(TParameter parameter);
    }
}
