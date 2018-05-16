using CartAPI.Service.Status.Attributes;

namespace CartAPI.Service.Status
{
    /// <summary>
    /// UserStatus
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public enum UserStatus
    {
        /// <summary>
        /// The success
        /// </summary>
        [Status("Sucess")]
        Success,

        /// <summary>
        /// The invalid credentials
        /// </summary>
        [Status("Invalid Credentials")]
        InvalidCredentials,
    }
}
