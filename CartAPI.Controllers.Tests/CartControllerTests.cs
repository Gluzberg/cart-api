using CartAPI.Controllers.Tests.Mocks;
using CartAPI.Data.Context;
using CartAPI.Data.Models;
using CartAPI.Models.Imp;
using CartAPI.Service.Imp;
using CartAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CartAPI.Controllers.Tests
{
    /// <summary>
    /// CartControllerTests
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class CartControllerTests
    {
        #region Get

        /// <summary>
        /// Get - not existing cart ID - should result Bad Request.
        /// </summary>
        [Fact]
        public void GetNotExisting()
        {
            CartController controller = new CartController(new CartService(Repositories.NonEmpty()));

            Assert.True(controller.Get(Guids.Cart.NotExisting) is BadRequestObjectResult);
        }

        /// <summary>
        ///  Get - existing cart ID - should result Ok response with the cart structure with the same cart ID.
        /// </summary>
        [Fact]
        public void GetExisting()
        {
            CartController controller = new CartController(new CartService(Repositories.NonEmpty()));

            IActionResult actionResult = controller.Get(Guids.Cart.Existing);
            
            Assert.True(actionResult is OkObjectResult);

            OkObjectResult result = actionResult as OkObjectResult;

            Assert.True(result.Value is CartViewModel);

            CartViewModel viewModel = result.Value as CartViewModel;

            Assert.Equal(viewModel.CartId, Guids.Cart.Existing);
        }

        #endregion

        #region Post

        /// <summary>
        /// Post - existing cart ID - should result Bad Request.
        /// </summary>
        [Fact]
        public void PostExisting()
        {
            CartController controller = new CartController(new CartService(Repositories.NonEmpty()));

            Assert.True(controller.Post(Guids.Cart.Existing) is BadRequestObjectResult);
        }

        /// <summary>
        /// Post - invalid cart ID - should result Bad Request.
        /// </summary>
        [Fact]
        public void PostInvalidId()
        {
            CartController controller = new CartController(new CartService(Repositories.NonEmpty()));

            Assert.True(controller.Post(null) is BadRequestObjectResult);
        }

        /// <summary>
        /// Post - not existing cart ID - should result Ok response with the cart structure with the same cart ID.
        /// </summary>
        [Fact]
        public void PostNew()
        {
            CartController controller = new CartController(new CartService(Repositories.NonEmpty()));

            IActionResult actionResult = controller.Post(Guids.Cart.New);

            Assert.True(actionResult is OkObjectResult);

            OkObjectResult result = actionResult as OkObjectResult;

            Assert.True(result.Value is CartViewModel);

            CartViewModel viewModel = result.Value as CartViewModel;

            Assert.Equal(viewModel.CartId, Guids.Cart.New);
        }

        #endregion

        #region Put

        /// <summary>
        /// Put - invalid cart ID - should result Bad Request.
        /// </summary>
        [Fact]
        public void PutInvalidId()
        {
            CartController controller = new CartController(new CartService(Repositories.NonEmpty()));

            Assert.True(controller.Put(null) is BadRequestObjectResult);
        }

        /// <summary>
        /// Put - not existing cart ID - should result Bad Request.
        /// </summary>
        [Fact]
        public void PutNonExisting()
        {
            CartController controller = new CartController(new CartService(Repositories.NonEmpty()));

            Assert.True(controller.Put(new CartViewModel() { CartId = Guids.Cart.NotExisting }) is BadRequestObjectResult);
        }

        /// <summary>
        /// Put- existing cart ID and valid product - should result Ok response with the cart structure with the same cart ID and the added product.
        /// </summary>
        [Fact]
        public void PutAddProduct()
        {
            CartController controller = new CartController(new CartService(Repositories.NonEmpty()));

            CartViewModel cart = new CartViewModel() { CartId = Guids.Cart.Existing };

            cart.Products = new ProductViewModel[] { Products.NewProduct };

            IActionResult actionResult = controller.Put(cart);

            Assert.True(actionResult is OkObjectResult);

            OkObjectResult result = actionResult as OkObjectResult;

            Assert.True(result.Value is CartViewModel);

            CartViewModel viewModel = result.Value as CartViewModel;

            Assert.NotNull(viewModel.Products);

            ProductViewModel product = viewModel.Products.FirstOrDefault(p => p.ProductId.Equals(Products.NewProduct.ProductId));

            Assert.NotNull(product);

            Assert.Equal(product.Amount, Products.NewProduct.Amount);
        }

        /// <summary>
        /// Put- existing cart ID and valid product - should result Ok response with the cart structure with the same cart ID and the modified product.
        /// </summary>
        [Fact]
        public void PutModifyProduct()
        {
            CartController controller = new CartController(new CartService(Repositories.NonEmpty()));

            CartViewModel cart = new CartViewModel() { CartId = Guids.Cart.Existing };

            ProductViewModel productModified = new ProductViewModel()
            {
                ProductId = Guids.Product.Existing,
                Amount = Methods.GetRandomAmount()
            };

            cart.Products = new ProductViewModel[] { productModified };

            IActionResult actionResult = controller.Put(cart);

            Assert.True(actionResult is OkObjectResult);

            OkObjectResult result = actionResult as OkObjectResult;

            Assert.True(result.Value is CartViewModel);

            CartViewModel viewModel = result.Value as CartViewModel;

            Assert.NotNull(viewModel.Products);

            ProductViewModel product = viewModel.Products.FirstOrDefault(p => p.ProductId.Equals(Products.ExistingProduct.ProductId));

            Assert.NotNull(product);

            Assert.Equal(product.Amount, productModified.Amount);
        }

        #endregion

        #region Delete

        /// <summary>
        /// Delete - invalid cart ID - should result Bad Request.
        /// </summary>
        [Fact]
        public void DeleteInvalidId()
        {
            CartController controller = new CartController(new CartService(Repositories.NonEmpty()));

            Assert.True(controller.Delete(null) is BadRequestObjectResult);
        }

        /// <summary>
        /// Delete - not existing cart ID - should result Bad Request.
        /// </summary>
        [Fact]
        public void DeleteNonExisting()
        {
            CartController controller = new CartController(new CartService(Repositories.NonEmpty()));

            Assert.True(controller.Delete(Guids.Cart.NotExisting) is BadRequestObjectResult);
        }

        /// <summary>
        /// Delete - existing cart ID - should result Ok response. Get with the same cart ID results then Bad Request.
        /// </summary>
        [Fact]
        public void DeleteExisting()
        {
            CartController controller = new CartController(new CartService(Repositories.NonEmpty()));

            IActionResult actionResult = controller.Delete(Guids.Cart.Existing);

            Assert.True(actionResult is OkObjectResult);

            actionResult = controller.Get(Guids.Cart.Existing);

            Assert.True(actionResult is BadRequestObjectResult);
        }

        #endregion

        #region Non-Public Members

        /// <summary>
        /// Methods
        /// </summary>
        protected static class Methods
        {
            /// <summary>
            /// The get random amount
            /// </summary>
            public static Func<uint> GetRandomAmount = () => (uint)(new Random().Next(1, 100));
        }

        /// <summary>
        /// Guids
        /// </summary>
        protected static class Guids
        {
            /// <summary>
            /// 
            /// </summary>
            public static class Cart
            {
                /// <summary>
                /// The existing
                /// </summary>
                public static readonly Guid Existing = Guid.NewGuid();

                /// <summary>
                /// The not existing
                /// </summary>
                public static readonly Guid NotExisting = Guid.NewGuid();

                /// <summary>
                /// The random
                /// </summary>
                public static readonly Guid Random = Guid.NewGuid();

                /// <summary>
                /// The new
                /// </summary>
                public static readonly Guid New = Guid.NewGuid();
            }

            /// <summary>
            /// 
            /// </summary>
            public static class Product
            {
                /// <summary>
                /// The existing
                /// </summary>
                public static readonly Guid Existing = Guid.NewGuid();

                /// <summary>
                /// The not existing
                /// </summary>
                public static readonly Guid NotExisting = Guid.NewGuid();

                /// <summary>
                /// The random
                /// </summary>
                public static readonly Guid Random = Guid.NewGuid();

                /// <summary>
                /// The new
                /// </summary>
                public static readonly Guid New = Guid.NewGuid();
            }
        }

        /// <summary>
        /// Products
        /// </summary>
        protected static class Products
        {
            /// <summary>
            /// The existing product
            /// </summary>
            public static readonly ProductViewModel ExistingProduct =
                new ProductViewModel() { ProductId = Guids.Product.Existing, Amount = Methods.GetRandomAmount() };

            /// <summary>
            /// The new product
            /// </summary>
            public static readonly ProductViewModel NewProduct = 
                new ProductViewModel() { ProductId = Guids.Product.New, Amount = Methods.GetRandomAmount() };
        }

        /// <summary>
        /// Repositories
        /// </summary>
        protected static class Repositories
        {
            /// <summary>
            /// The empty
            /// </summary>
            public static Func<ICartRepository> Empty = () => new CartMockRepository();

            /// <summary>
            /// The non empty
            /// </summary>
            public static Func<ICartRepository> NonEmpty = () => new CartMockRepository(
                new Dictionary<Guid, ICart>()
                {
                    { Guids.Cart.Existing, new Cart()
                        {
                            Id = Guids.Cart.Existing,
                            Products = new IProduct [] { new Product() { Id = Guids.Product.Existing, Amount = (uint)(new Random().Next(1, 100)) }}
                        }
                    },
                    { Guids.Cart.Random, new Cart() {  Id = Guids.Cart.Random, Products = new IProduct[0] } }
                });
        }

        #endregion
    }
}
