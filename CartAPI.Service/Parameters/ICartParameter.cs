using CartAPI.Data.Models;

namespace CartAPI.Service.Parameters
{
    /// <summary>
    /// ICartParameter
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface ICartParameter
    {
        /// <summary>
        /// Gets the cart.
        /// </summary>
        /// <value>
        /// The cart.
        /// </value>
        ICart Cart { get; }

        /// <summary>
        /// Gets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        Enums.Action Action { get; }
    }
}
