using CartAPI.Data;
using CartAPI.Service.Status;

namespace CartAPI.Service.Results
{
    /// <summary>
    /// IUserResult
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface IUserResult
    {
        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        UserStatus Status { get; }

        /// <summary>
        /// Gets the authorization.
        /// </summary>
        /// <value>
        /// The authorization.
        /// </value>
        IAuthorization Authorization { get; }
    }
}
