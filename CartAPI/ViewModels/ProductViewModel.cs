using CartAPI.Data.Models;
using CartAPI.Models.Imp;
using CartAPI.ViewModels.Base;
using System;

namespace CartAPI.ViewModels
{
    /// <summary>
    /// ProductViewModel
    /// </summary>
    /// <seealso cref="Base.IViewModel{IProduct}" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class ProductViewModel : IViewModel<IProduct>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductViewModel"/> class.
        /// </summary>
        public ProductViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductViewModel"/> class.
        /// </summary>
        /// <param name="product">The product.</param>
        public ProductViewModel(IProduct product)
        {
            this.ProductId = product.Id;
            this.Amount = product.Amount;
        }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public uint Amount { get; set; }

        /// <summary>
        /// To the data model.
        /// </summary>
        /// <returns>Coresponsing data model</returns>
        public IProduct ToDataModel()
        {
            return new Product()
            {
                Id = this.ProductId,
                Amount = this.Amount
            };
        }
    }
}
