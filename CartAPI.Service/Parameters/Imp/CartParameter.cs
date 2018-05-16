using CartAPI.Data.Models;

namespace CartAPI.Service.Parameters.Imp
{
    /// <summary>
    /// CartParameter
    /// </summary>
    /// <seealso cref="ICartParameter" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class CartParameter : ICartParameter
    {
        /// <summary>
        /// Gets or sets the cart.
        /// </summary>
        /// <value>
        /// The cart.
        /// </value>
        public ICart Cart { get; set; }

        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        public Enums.Action Action { get; set; }
    }
}
