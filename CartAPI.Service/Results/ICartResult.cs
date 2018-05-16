using CartAPI.Data.Models;
using CartAPI.Service.Status;

namespace CartAPI.Service.Result
{
    /// <summary>
    /// ICartResult
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface ICartResult
    {
        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        CartStatus Status { get; }

        /// <summary>
        /// Gets the cart.
        /// </summary>
        /// <value>
        /// The cart.
        /// </value>
        ICart Cart { get; }
    }
}
