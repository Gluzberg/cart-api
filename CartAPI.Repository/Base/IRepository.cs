using CartAPI.Repository.Entity;
using System;
using System.Collections.Generic;

namespace CartAPI.Repository
{
    /// <summary>
    /// IRepistory
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface IRepository<TEntity, TKey> where TEntity : IEntity<TKey> where TKey : IComparable
    {
        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The added entity</returns>
        TEntity Add(TEntity item);

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The updated entity</returns>
        TEntity Update(TEntity item);

        /// <summary>
        /// Gets the by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The entity with the corresponding key</returns>
        TEntity GetByKey(TKey key);

        /// <summary>
        /// Deletes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>True if deleting was successfull, false otherwise</returns>
        bool Delete(TKey key);

        /// <summary>
        /// Selects all.
        /// </summary>
        /// <returns>All entities in the repository</returns>
        IEnumerable<TEntity> SelectAll();
    }
}
