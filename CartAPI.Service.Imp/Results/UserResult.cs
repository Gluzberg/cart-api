using CartAPI.Service.Results;
using CartAPI.Data;
using CartAPI.Service.Status;

namespace CartAPI.Service.Imp.Results
{
    /// <summary>
    /// USerResult
    /// </summary>
    /// <seealso cref="CartAPI.Service.Results.IUserResult" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class UserResult : IUserResult
    {
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public UserStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the authorization.
        /// </summary>
        /// <value>
        /// The authorization.
        /// </value>
        public IAuthorization Authorization { get; set; }
    }
}
