using CartAPI.Data.Models;

namespace CartAPI.Service.Parameters.Imp
{
    /// <summary>
    /// UserParameter
    /// </summary>
    /// <seealso cref="CartAPI.Service.Parameters.IUserParameter" />
    public class UserParameter : IUserParameter
    {
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public IUser User { get; set; }
    }
}
