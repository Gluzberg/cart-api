using CartAPI.Data.Models;
using CartAPI.Repository.Imp;
using System;
using System.Collections.Generic;

namespace CartAPI.Data.Context.Imp
{
    /// <summary>
    /// CartMemoryRepository
    /// </summary>
    /// <seealso cref="CartAPI.Repository.Imp.MemoryRepository{CartAPI.Data.Models.ICart, System.Guid}" />
    /// <seealso cref="CartAPI.Data.Context.ICartRepository" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class CartMemoryRepository : MemoryRepository<ICart, Guid>, ICartRepository
    {
    }
}
