using CartAPI.Data.Models;
using CartAPI.Models.Imp;
using CartAPI.ViewModels.Base;
using System;
using System.Linq;

namespace CartAPI.ViewModels
{
    /// <summary>
    /// CartViewModel
    /// </summary>
    /// <seealso cref="Base.IViewModel{ICart}" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class CartViewModel : IViewModel<ICart>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CartViewModel"/> class.
        /// </summary>
        public CartViewModel()
        {
            this.Products = new ProductViewModel[0];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CartViewModel"/> class.
        /// </summary>
        /// <param name="cart">The cart.</param>
        public CartViewModel(ICart cart)
        {
            this.CartId = cart.Id;
            this.Products = cart.Products.Select(m => new ProductViewModel(m)).ToArray();
        }

        /// <summary>
        /// Gets or sets the cart identifier.
        /// </summary>
        /// <value>
        /// The cart identifier.
        /// </value>
        public Guid CartId { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>
        /// The products.
        /// </value>
        public ProductViewModel[] Products { get; set; }

        /// <summary>
        /// To the data model.
        /// </summary>
        /// <returns>Corresponding data model</returns>
        public ICart ToDataModel()
        {
            return new Cart()
            {
                Id = this.CartId,
                Products = this.Products.Select(m => m.ToDataModel()).ToArray()
            };
        }
    }
}
