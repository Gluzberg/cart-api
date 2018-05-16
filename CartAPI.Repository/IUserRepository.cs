using CartAPI.Data.Models;

namespace CartAPI.Repository
{
    /// <summary>
    /// IUserRepostory
    /// </summary>
    /// <seealso cref="Repository.IRepository{IUser, System.String}" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface IUserRepository : IRepository<IUser, string>
    {
    }
}
