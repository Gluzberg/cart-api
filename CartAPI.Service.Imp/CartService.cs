using System;
using System.Collections.Generic;
using CartAPI.Service.Parameters;
using CartAPI.Service.Status;
using CartAPI.Data.Context;
using CartAPI.Service.Result;
using CartAPI.Data.Models;
using CartAPI.Service.Imp.Results;
using System.Linq;
using CartAPI.Models.Imp;

namespace CartAPI.Service.Imp
{
    /// <summary>
    /// CartService
    /// </summary>
    /// <seealso cref="ICartService" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class CartService : ICartService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CartService"/> class.
        /// </summary>
        /// <param name="cartRepository">The cart repository.</param>
        public CartService(ICartRepository cartRepository)
        {
            this.CartRepository = cartRepository;
        }

        /// <summary>
        /// Executes the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>Execution result if was successful and action status</returns>
        public ICartResult Execute(ICartParameter parameter)
        {
            Func<CartService, ICart, ICartResult> method;

            return parameter != null && 
                parameter.Cart != null && 
                ActionToMethod.TryGetValue(parameter.Action, out method) ?
                method(this, parameter.Cart) :
                new CartResult() { Status = CartStatus.InvalidId };
        }

        #region Non-Public Members 

        /// <summary>
        /// Reads the specified cart.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <returns>The read cart if was successful and action status</returns>
        protected ICartResult Read(ICart cart)
        {
            ICart resultCart = null;

            CartStatus status = CartStatus.InvalidId;

            if (cart != null && cart.Id != null)
            {
                resultCart = this.CartRepository.GetByKey(cart.Id);

                status = resultCart != null ? CartStatus.Success : CartStatus.MissingCart;
            }

            return new CartResult()
            {
                Cart = resultCart,
                Status = status
            };
        }

        /// <summary>
        /// Inserts the specified cart.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <returns>The inserted cart if was successful and action status</returns>
        protected ICartResult Insert(ICart cart)
        {
            ICart resultCart = null;

            CartStatus status = CartStatus.InvalidId;

            if (cart != null && cart.Id != null)
            {
                status = this.CartRepository.GetByKey(cart.Id) != null ?
                    CartStatus.ExistingCart : 
                    ((resultCart = this.CartRepository.Add(cart)) != null ? CartStatus.Success : CartStatus.RepositoryError);
            } 

            return new CartResult()
            {
                Cart = resultCart,
                Status = status
            };
        }

        /// <summary>
        /// Updates the specified cart.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <returns>The updated cart if was successful and action status</returns>
        protected ICartResult Update(ICart cart)
        {
            ICartResult readResult = this.Read(cart);

            if (readResult.Status != CartStatus.Success)
            {
                return readResult;
            }

            IEnumerable<Guid> toUpdate = cart.Products.Select(p => p.Id);

            IEnumerable<IProduct> products = readResult.Cart.Products
                .Where(p => !toUpdate.Contains(p.Id))
                .Concat(cart.Products.Where(p => p.Amount > 0) ?? new IProduct[0]);

            ICart resultCart = this.CartRepository.Update(new Cart()
            {
                Id = cart.Id,
                Products = products.ToArray()
            });

            return new CartResult()
            {
                Cart = resultCart,
                Status = resultCart != null ? CartStatus.Success : CartStatus.RepositoryError
            };
        }

        /// <summary>
        /// Deletes the specified cart.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <returns>The deleted cart if was successful and action status</returns>
        protected ICartResult Delete(ICart cart)
        {
            ICart resultCart = null;

            CartStatus status = CartStatus.InvalidId;

            if (cart != null && cart.Id != null)
            {
                status = this.CartRepository.GetByKey(cart.Id) == null ?
                     CartStatus.MissingCart :
                     this.CartRepository.Delete(cart.Id) ? CartStatus.Success : CartStatus.RepositoryError;

                resultCart = status == CartStatus.Success ? cart : null;
            }

            return new CartResult()
            {
                Cart = resultCart,
                Status = status
            };
        }

        /// <summary>
        /// Gets the cart repository.
        /// </summary>
        /// <value>
        /// The cart repository.
        /// </value>
        protected ICartRepository CartRepository { get; private set; }

        /// <summary>
        /// The action to method
        /// </summary>
        protected static readonly IDictionary<Parameters.Enums.Action, Func<CartService, ICart, ICartResult>> ActionToMethod =
            new Dictionary<Parameters.Enums.Action, Func<CartService, ICart, ICartResult>>
            {
                { Parameters.Enums.Action.Insert, (s, c) => s.Insert(c) },
                { Parameters.Enums.Action.Read, (s, c) => s.Read(c) },
                { Parameters.Enums.Action.Update, (s, c) => s.Update(c) },
                { Parameters.Enums.Action.Delete, (s, c) => s.Delete(c) }
            };

        #endregion
    }
}
