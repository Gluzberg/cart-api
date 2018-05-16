using CartAPI.Data.Context.Imp;
using CartAPI.Data.Models;
using System;
using System.Collections.Generic;

namespace CartAPI.Controllers.Tests.Mocks
{
    /// <summary>
    /// CartMockRepository
    /// </summary>
    /// <seealso cref="CartMemoryRepository" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class CartMockRepository : CartMemoryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CartMockRepository"/> class.
        /// </summary>
        public CartMockRepository()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CartMockRepository"/> class.
        /// </summary>
        /// <param name="values">The values.</param>
        public CartMockRepository(IDictionary<Guid, ICart> values)
        {
            this.Values = values;
        }
    }
}
