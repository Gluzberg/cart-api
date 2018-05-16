using CartAPI.Controllers.Security;
using CartAPI.Controllers.Tests.Mocks;
using CartAPI.Data.Context.Imp;
using CartAPI.Service.Imp;
using CartAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Xunit;

namespace CartAPI.Controllers.Tests
{
    /// <summary>
    /// TokenControllerTests
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class TokenControllerTests
    {
        #region Post

        /// <summary>
        /// Valid credentials and missings configuration, should result Unauthorized. 
        /// </summary>
        [Fact]
        public void MissingConfiguration()
        {
            TokenController controller = new TokenController(new UserService(Configurations.Blank, new UserMemoryRepository()));

            Assert.True(controller.Post(UserViewModels.ValidCredenatials) is UnauthorizedResult);
        }

        /// <summary>
        /// Valid the credentials and valid configuration, should return valid Ok result with valid token.
        /// </summary>
        [Fact]
        public void ValidCredentialsAndConfiguration()
        {
            TokenController controller = new TokenController(new UserService(Configurations.Valid, new UserMemoryRepository()));

            IActionResult actionResult = controller.Post(UserViewModels.ValidCredenatials);

            Assert.True(actionResult is OkObjectResult);

            OkObjectResult result = actionResult as OkObjectResult;

            Assert.True(result.Value is AuthorizationViewModel);

            AuthorizationViewModel viewModel = result.Value as AuthorizationViewModel;

            Assert.NotNull(viewModel.Token);

            Assert.NotEmpty(viewModel.Token);
        }

        /// <summary>
        /// Invalid username and valid configuration, should result Unauthorized. 
        /// </summary>
        [Fact]
        public void InvalidUsernameAndConfiguration()
        {
            TokenController controller = new TokenController(new UserService(Configurations.Valid, new UserMemoryRepository()));

            Assert.True(controller.Post(UserViewModels.InvalidUsername) is UnauthorizedResult);
        }

        /// <summary>
        /// Invalid password and valid configuration, should result Unauthorized. 
        /// </summary>
        [Fact]
        public void InvalidPasswordAndConfiguration()
        {
            TokenController controller = new TokenController(new UserService(Configurations.Valid, new UserMemoryRepository()));

            Assert.True(controller.Post(UserViewModels.InvalidPassword) is UnauthorizedResult);
        }

        /// <summary>
        /// Null the username and valid configuration, should result Unauthorized.
        /// </summary>
        [Fact]
        public void NullUsernameAndConfiguration()
        {
            TokenController controller = new TokenController(new UserService(Configurations.Valid, new UserMemoryRepository()));

            Assert.True(controller.Post(UserViewModels.NullUsername) is UnauthorizedResult);
        }

        /// <summary>
        /// Null password and valid configuration, should result Unauthorized.
        /// </summary>
        [Fact]
        public void NullPasswordAndConfiguration()
        {
            TokenController controller = new TokenController(new UserService(Configurations.Valid, new UserMemoryRepository()));

            Assert.True(controller.Post(UserViewModels.NullPassword) is UnauthorizedResult);
        }

        #endregion

        #region Non-Public Memebers 

        /// <summary>
        /// Configuration
        /// </summary>
        protected static class Configurations
        {
            /// <summary>
            /// The blank
            /// </summary>
            public static readonly IConfiguration Blank = new MockConfiguration();

            /// <summary>
            /// The valid
            /// </summary>
            public static readonly IConfiguration Valid =
                new MockConfiguration(new Dictionary<string, string>()
                {
                    { "Jwt:Key", "veryVerySecretKey" },
                    { "Jwt:Issuer", "http://localhost:52865/" }
                }
            );
        }

        /// <summary>
        /// UserViewModel
        /// </summary>
        protected static class UserViewModels
        {
            /// <summary>
            /// The valid credenatials
            /// </summary>
            public static UserViewModel ValidCredenatials = new UserViewModel()
            {
                Username = "test_user@gmail.com",
                Password = "secret_password"
            };
            /// <summary>
            /// The invalid username
            /// </summary>
            public static UserViewModel InvalidUsername = new UserViewModel()
            {
                Username = "test_user#gmail.com",
                Password = "secret_password"
            };
            /// <summary>
            /// The invalid password
            /// </summary>
            public static UserViewModel InvalidPassword = new UserViewModel()
            {
                Username = "test_user@gmail.com",
                Password = "secret-password"
            };
            /// <summary>
            /// The null username
            /// </summary>
            public static UserViewModel NullUsername = new UserViewModel()
            {
                Username = "null",
                Password = "secret_password"
            };
            /// <summary>
            /// The null password
            /// </summary>
            public static UserViewModel NullPassword = new UserViewModel()
            {
                Username = "test_user@gmail.com",
                Password = null
            };
        }

        #endregion
    }
}
