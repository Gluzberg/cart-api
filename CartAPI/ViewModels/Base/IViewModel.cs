namespace CartAPI.ViewModels.Base
{
    /// <summary>
    /// IViewModel
    /// </summary>
    /// <typeparam name="TData">The type of the data.</typeparam>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface IViewModel<TData>
    {
        /// <summary>
        /// To the data model.
        /// </summary>
        /// <returns>Corresponding data model</returns>
        TData ToDataModel();
    }
}
