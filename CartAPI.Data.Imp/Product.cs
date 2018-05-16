using CartAPI.Data.Models;
using System;

namespace CartAPI.Models.Imp
{
    /// <summary>
    /// Product
    /// </summary>
    /// <seealso cref="IProduct" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class Product : IProduct
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public uint Amount { get; set; }
    }
}
