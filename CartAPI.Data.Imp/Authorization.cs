namespace CartAPI.Data.Imp
{
    /// <summary>
    /// Authorization
    /// </summary>
    /// <seealso cref="Data.IAuthorization" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class Authorization : IAuthorization
    {
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public string Token { get; set; }
    }
}
