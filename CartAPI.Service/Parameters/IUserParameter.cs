using CartAPI.Data.Models;

namespace CartAPI.Service.Parameters
{
    /// <summary>
    /// IUserParameter
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface IUserParameter
    {
        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        IUser User { get; }
    }
}
