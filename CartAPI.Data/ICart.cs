using CartAPI.Repository.Entity;
using System;

namespace CartAPI.Data.Models
{
    /// <summary>
    /// ICart
    /// </summary>
    /// <seealso cref="Repository.Entity.IEntity{System.Guid}" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface ICart : IEntity<Guid>
    {
        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <value>
        /// The products.
        /// </value>
        IProduct[] Products { get; }
    }
}
