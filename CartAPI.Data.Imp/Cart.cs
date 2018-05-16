using CartAPI.Data.Models;
using System;

namespace CartAPI.Models.Imp
{
    /// <summary>
    /// Cart
    /// </summary>
    /// <seealso cref="Data.Models.ICart" />
    public class Cart : ICart
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cart"/> class.
        /// </summary>
        /// <author>
        /// M. Gluzberg, May-2018
        /// </author>
        public Cart()
        {
            this.Products = new IProduct[0];
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>
        /// The products.
        /// </value>
        public IProduct[] Products { get; set; }
    }
}
