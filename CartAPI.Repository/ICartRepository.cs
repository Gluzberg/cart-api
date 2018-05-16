using CartAPI.Data.Models;
using CartAPI.Repository;
using System;

namespace CartAPI.Data.Context
{
    /// <summary>
    /// ICartRepository
    /// </summary>
    /// <seealso cref="Repository.IRepository{CartAPI.Data.Models.ICart, System.Guid}" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface ICartRepository : IRepository<ICart, Guid>
    {
    }
}
