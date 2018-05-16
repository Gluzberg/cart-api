using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;

namespace CartAPI.Controllers.Tests.Mocks
{
    /// <summary>
    /// MockConfiguration
    /// </summary>
    /// <seealso cref="Microsoft.Extensions.Configuration.IConfiguration" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class MockConfiguration : IConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MockConfiguration"/> class.
        /// </summary>
        public MockConfiguration()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MockConfiguration"/> class.
        /// </summary>
        /// <param name="configurationValues">The configuration values.</param>
        public MockConfiguration(IDictionary<string, string> configurationValues)
        {
            this.ConfigurationValues = configurationValues;
        }

        /// <summary>
        /// Gets or sets the <see cref="System.String" /> with the specified key.
        /// </summary>
        /// <value>
        /// The <see cref="System.String" />.
        /// </value>
        /// <param name="key">The key.</param>
        /// <returns>
        /// Value for given Key if such exists, otherwise null
        /// </returns>
        public string this[string key]
        {
            get
            {
                string value;

                return this.ConfigurationValues.TryGetValue(key, out value) ? value : key;
            }
            set
            {
                if (this.ConfigurationValues.ContainsKey(key))
                {
                    this.ConfigurationValues.Remove(key);
                }

                this.ConfigurationValues.Add(key, value);
            }
        }

        /// <summary>
        /// Gets the immediate descendant configuration sub-sections.
        /// </summary>
        /// <returns>
        /// The configuration sub-sections.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<IConfigurationSection> GetChildren()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a <see cref="T:Microsoft.Extensions.Primitives.IChangeToken" /> that can be used to observe when this configuration is reloaded.
        /// </summary>
        /// <returns>
        /// A <see cref="T:Microsoft.Extensions.Primitives.IChangeToken" />.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public IChangeToken GetReloadToken()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a configuration sub-section with the specified key.
        /// </summary>
        /// <param name="key">The key of the configuration section.</param>
        /// <returns>
        /// The <see cref="T:Microsoft.Extensions.Configuration.IConfigurationSection" />.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        /// <remarks>
        /// This method will never return <c>null</c>. If no matching sub-section is found with the specified key,
        /// an empty <see cref="T:Microsoft.Extensions.Configuration.IConfigurationSection" /> will be returned.
        /// </remarks>
        public IConfigurationSection GetSection(string key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The configuration values
        /// </summary>
        protected readonly IDictionary<string, string> ConfigurationValues = new Dictionary<string, string>();
    }
}
