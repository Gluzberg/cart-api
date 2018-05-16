using CartAPI.Data;

namespace CartAPI.ViewModels
{
    /// <summary>
    /// AuthorizationViewModel
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class AuthorizationViewModel 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationViewModel"/> class.
        /// </summary>
        /// <param name="authorization">The authorization.</param>
        public AuthorizationViewModel(IAuthorization authorization)
        {
            this.Token = authorization.Token;
        }

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public string Token { get; set; }
    }
}
