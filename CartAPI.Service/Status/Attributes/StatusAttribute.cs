using System;
using System.Linq;
using System.Reflection;

namespace CartAPI.Service.Status.Attributes
{
    /// <summary>
    /// Status Attribute
    /// </summary>
    /// <seealso cref="System.Attribute" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class StatusAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatusAttribute"/> class.
        /// </summary>
        /// <param name="description">The description.</param>
        public StatusAttribute(string description)
        {
            this.Description = description;
        }

        /// <summary>
        /// Description
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// GetDescritption
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>Enum value description text.</returns>
        public static string GetDescritption<TEntity>(TEntity value)
        {
            MemberInfo[] memberInfo = typeof(TEntity).GetMember(value.ToString());

            object[] attributes = memberInfo.Any() ? memberInfo.First().GetCustomAttributes(typeof(StatusAttribute), false) : null;
            object firstAttribute = attributes != null && attributes.Any() ? attributes.First() : null;

            return firstAttribute != null && firstAttribute is StatusAttribute ? (firstAttribute as StatusAttribute).Description : value.ToString();
        }
    }
}
