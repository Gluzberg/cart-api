using CartAPI.Data.Models;
using CartAPI.Models.Imp;
using CartAPI.Repository;
using CartAPI.Repository.Imp;

namespace CartAPI.Data.Context.Imp
{
    /// <summary>
    /// UserMemoryRepository
    /// </summary>
    /// <seealso cref="CartAPI.Repository.Imp.MemoryRepository{CartAPI.Data.Models.IUser, System.String}" />
    /// <seealso cref="CartAPI.Repository.IUserRepository" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class UserMemoryRepository : MemoryRepository<IUser, string>, IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserMemoryRepository"/> class.
        /// </summary>
        public UserMemoryRepository()
        {
            this.Add(new User()
            {
                Id = "test_user@gmail.com",
                Password = "secret_password"
            });
        }
    }
}
