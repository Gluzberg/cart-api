using CartAPI.Repository.Entity;
using System;
using System.Collections.Generic;

namespace CartAPI.Repository.Imp
{
    /// <summary>
    /// MemoryReposotiry
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <seealso cref="CartAPI.Repository.IRepository{TEntity, TKey}" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    /// <seealso cref="CartAPI.Repository.IRepository{T, TKey}" />
    public class MemoryRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : IEntity<TKey> where TKey : IComparable
    {
        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The added entity, if adding was successful. Default value otherwise.</returns>
        public TEntity Add(TEntity item)
        {
            lock (this.Values)
            {
                return this.Values.TryAdd(item.Id, item) ? item : FallbackValue;
            }
        }

        /// <summary>
        /// Deletes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>True if deleting was succesful, false otherwise.</returns>
        public bool Delete(TKey key)
        {
            lock (this.Values)
            {
                return this.Values.Remove(key);
            }
        }

        /// <summary>
        /// Gets the by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Entity with the specified key if such exists. Otherwise the default value of the Entity type</returns>
        public TEntity GetByKey(TKey key)
        {
            TEntity value;

            lock (this.Values)
            {
                return key != null && this.Values.TryGetValue(key, out value) ? value : FallbackValue;
            }
        }

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The updated item</returns>
        public TEntity Update(TEntity item)
        {
            lock (this.Values)
            {
                return this.Values.Remove(item.Id) ? (this.Values.TryAdd(item.Id, item) ? item : FallbackValue) : FallbackValue;
            }
        }

        /// <summary>
        /// Selects all.
        /// </summary>
        /// <returns>All Entities in the Repository</returns>
        public IEnumerable<TEntity> SelectAll() => this.Values.Values;

        #region Non-Public

        /// <summary>
        /// The values
        /// </summary>
        protected IDictionary<TKey, TEntity> Values = new Dictionary<TKey, TEntity>();

        /// <summary>
        /// The fallback value
        /// </summary>
        protected static readonly TEntity FallbackValue = default(TEntity);

        #endregion
    }
}
