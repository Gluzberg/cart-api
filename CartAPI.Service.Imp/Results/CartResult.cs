using CartAPI.Service.Result;
using CartAPI.Service.Status;
using CartAPI.Data.Models;

namespace CartAPI.Service.Imp.Results
{
    /// <summary>
    /// CartResult
    /// </summary>
    /// <seealso cref="CartAPI.Service.Result.ICartResult" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class CartResult : ICartResult
    {
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public CartStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the cart.
        /// </summary>
        /// <value>
        /// The cart.
        /// </value>
        public ICart Cart { get; set; }
    }
}
