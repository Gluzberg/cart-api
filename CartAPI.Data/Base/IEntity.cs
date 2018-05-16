namespace CartAPI.Repository.Entity
{
    /// <summary>
    /// IEntity
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface IEntity<TKey>
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        TKey Id { get; }
    }
}
