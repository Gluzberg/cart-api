using CartAPI.Service.Parameters;
using CartAPI.Service.Status;
using CartAPI.Repository;
using CartAPI.Data.Models;
using Microsoft.Extensions.Configuration;
using CartAPI.Service.Results;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CartAPI.Service.Imp.Results;
using System;

namespace CartAPI.Service.Imp
{
    /// <summary>
    /// UserService
    /// </summary>
    /// <seealso cref="IUserService" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class UserService : IUserService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="userRepository">The user repository.</param>
        public UserService (IConfiguration configuration, IUserRepository userRepository)
        {
            this.Configuration = configuration;
            this.UserRepository = userRepository;
        }

        /// <summary>
        /// Executes the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        public IUserResult Execute(IUserParameter parameter)
        {
            IUser user = parameter != null && parameter.User != null ? this.UserRepository.GetByKey(parameter.User.Id) : null;

            string token = string.Empty;
             
            UserStatus status = user != null && user.Password.Equals(parameter.User.Password) && (token = this.BuildToken()) != null ? 
                UserStatus.Success : 
                UserStatus.InvalidCredentials;

            return new UserResult()
            {
                Authorization = status == UserStatus.Success ?
                    new Data.Imp.Authorization() { Token = token } : 
                    null,
                Status = status
            };
        }

        #region Non-Public Memners

        /// <summary>
        /// Gets the user repository.
        /// </summary>
        /// <value>
        /// The user repository.
        /// </value>
        protected IUserRepository UserRepository { get; private set; }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        protected IConfiguration Configuration { get; private set; }

        /// <summary>
        /// Builds the token.
        /// </summary>
        /// <returns>Token value</returns>
        private string BuildToken()
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Configuration[Labels.Key]));

            int expire;
            expire = int.TryParse(this.Configuration[Labels.Expire], out expire) ? expire : DefaultExpiration;

            SecurityToken token = new JwtSecurityToken(
              this.Configuration[Labels.Issuer],
              this.Configuration[Labels.Issuer],
              expires: DateTime.Now.AddHours(expire),
              signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            try
            {
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static class Labels
        {
            /// <summary>
            /// The key
            /// </summary>
            public const string Key = "Jwt:Key";

            /// <summary>
            /// The issuer
            /// </summary>
            public const string Issuer = "Jwt:Issuer";

            /// <summary>
            /// The issuer
            /// </summary>
            public const string Expire = "Jwt:Expire";
        }

        /// <summary>
        /// The default expiration
        /// </summary>
        private const int DefaultExpiration = 24;

        #endregion
    }
}