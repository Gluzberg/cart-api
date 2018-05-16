using CartAPI.Service;
using CartAPI.Service.Parameters.Imp;
using CartAPI.Service.Results;
using CartAPI.Service.Status;
using CartAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CartAPI.Controllers.Security
{
    /// <summary>
    /// TokenController
    /// </summary>
    /// <seealso cref="Controller" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenController"/> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        public TokenController(IUserService userService)
        {
            this.UserService = userService;
        }

        /// <summary>
        /// Posts the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>IActionResult</returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody]UserViewModel user)
        {
            IUserResult result = this.UserService.Execute(new UserParameter() { User = user != null ? user.ToDataModel() : null });
            
            return result.Status == UserStatus.Success ? 
                Ok(new AuthorizationViewModel(result.Authorization)) : 
                Unauthorized() as IActionResult;
        }

        /// <summary>
        /// Gets the user service.
        /// </summary>
        /// <value>
        /// The user service.
        /// </value>
        protected IUserService UserService { get; private set; }
    }
}