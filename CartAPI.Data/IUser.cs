using CartAPI.Repository.Entity;

namespace CartAPI.Data.Models
{
    /// <summary>
    /// IUser
    /// </summary>
    /// <seealso cref="Repository.Entity.IEntity{System.String}" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface IUser : IEntity<string>
    {
        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        string Password { get; }
    }
}
