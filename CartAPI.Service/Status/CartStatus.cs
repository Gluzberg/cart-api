using CartAPI.Service.Status.Attributes;

namespace CartAPI.Service.Status
{
    /// <summary>
    /// CartStatus
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public enum CartStatus
    {
        /// <summary>
        /// The success
        /// </summary>
        [Status("Sucess")]
        Success,

        /// <summary>
        /// The invalid identifier
        /// </summary>
        [Status("Cart ID was not specfied correctly, please use a correct GUID format")]
        InvalidId,

        /// <summary>
        /// The missing cart
        /// </summary>
        [Status("Cart with the specified ID already exist")]
        ExistingCart,


        /// <summary>
        /// The missing cart
        /// </summary>
        [Status("Cart with the specified ID does not exist")]
        MissingCart,

        /// <summary>
        /// The repository error
        /// </summary>
        [Status("Data storage error had occurred")]
        RepositoryError
    }
}
