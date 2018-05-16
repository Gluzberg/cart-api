using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CartAPI.Data.Models;
using CartAPI.Service;
using CartAPI.Service.Parameters.Imp;
using CartAPI.Models.Imp;
using CartAPI.Service.Result;
using CartAPI.Service.Status;
using CartAction = CartAPI.Service.Parameters.Enums.Action;
using CartAPI.ViewModels;
using CartAPI.Service.Status.Attributes;

namespace CartAPI.Controllers
{
    /// <summary>
    /// CartController
    /// </summary>
    /// <seealso cref="Controller" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CartController"/> class.
        /// </summary>
        /// <param name="cartService">The cart service.</param>
        public CartController(ICartService cartService)
        {
            this.CartService = cartService;
        }

        // GET api/cart
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>IActionResult</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult("Running");
        }

        // GET api/cart/{Cart Id}
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid? id)
        {
            return this.SubAction(id.HasValue ? new Cart() { Id = id.Value } : null, CartAction.Read);
        }

        // POST api/cart
        /// <summary>
        /// Posts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult</returns>
        [HttpPost("{id}")]
        public IActionResult Post(Guid? id)
        {
            return this.SubAction(id.HasValue ? new Cart() { Id = id.Value } : null, CartAction.Insert);
        }

        // PUT api/cart
        /// <summary>
        /// Puts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>IActionResult</returns>
        [HttpPut]
        public IActionResult Put([FromBody]CartViewModel value)
        {
            return this.SubAction(value != null ? value.ToDataModel() : null, CartAction.Update);
        }

        // DELETE api/cart/{Cart Id}
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid? id)
        {
            return this.SubAction(id.HasValue ? new Cart() { Id = id.Value } : null, CartAction.Delete);
        }

        #region Non-Public Members 

        /// <summary>
        /// Subs the action.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <param name="action">The action.</param>
        /// <returns>IActionResult</returns>
        [NonAction]
        protected IActionResult SubAction(ICart cart, CartAction action)
        {
            ICartResult result = this.CartService.Execute(new CartParameter()
            {
                Cart = cart,
                Action = action
            });

            return result.Status == CartStatus.Success ?
                (result.Cart != null ? new OkObjectResult(new CartViewModel(result.Cart)) :  (IActionResult)new OkResult())  : 
                BadRequestResult(StatusAttribute.GetDescritption(result.Status));
        }

        /// <summary>
        /// Gets the cart service.
        /// </summary>
        /// <value>
        /// The cart service.
        /// </value>
        protected ICartService CartService { get; private set; }

        #endregion

        #region Static

        /// <summary>
        /// 
        /// </summary>
        private static class Messages
        {
            /// <summary>
            /// The invalid identifier
            /// </summary>
            public const string InvalidId = "Cart ID was not specfied correctly, please use a correct GUID format";

            /// <summary>
            /// The missing cart
            /// </summary>
            public const string MissingCart = "Cart with the specified ID does not exist";

            /// <summary>
            /// The existing cart
            /// </summary>
            public const string ExistingCart = "Cart with the specified ID already exist";

            /// <summary>
            /// The missing product
            /// </summary>
            public const string MissingProduct = "Product with the specified ID does not exist in the corresponding Cart";

            /// <summary>
            /// The existing product
            /// </summary>
            public const string ExistingProduct = "Product with the specified ID already exists in the corresponding Cart";

            /// <summary>
            /// The repository error
            /// </summary>
            public const string RepositoryError = "Data repository error had occured";

            /// <summary>
            /// The cart deleted
            /// </summary>
            public const string CartDeleted = "Data repository error had occured";
        }

        /// <summary>
        /// The bad request result
        /// </summary>
        private static readonly Func<string, IActionResult> BadRequestResult = text => new BadRequestObjectResult(new { message = text });

        #endregion
    }
}
