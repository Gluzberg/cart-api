using CartAPI.Data.Models;
using CartAPI.Models.Imp;
using CartAPI.ViewModels.Base;

namespace CartAPI.ViewModels
{
    /// <summary>
    /// UserViewModel
    /// </summary>
    /// <seealso cref="Base.IViewModel{IUser}" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class UserViewModel : IViewModel<IUser>
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// To the data model.
        /// </summary>
        /// <returns>Corresponding data model</returns>
        public IUser ToDataModel()
        {
            return new User()
            {
                Id = this.Username,
                Password = this.Password
            };
        }
    }
}
