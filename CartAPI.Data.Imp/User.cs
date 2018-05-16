using CartAPI.Data.Models;

namespace CartAPI.Models.Imp
{
    /// <summary>
    /// User
    /// </summary>
    /// <seealso cref="Data.Models.IUser" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class User : IUser
    {
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }
    }
}
