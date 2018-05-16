using CartAPI.Service.Parameters;
using CartAPI.Service.Results;
using CartAPI.Service.Services.Base;

namespace CartAPI.Service
{
    /// <summary>
    /// IUserService
    /// </summary>
    /// <seealso cref="Services.Base.IService{IUserParameter, IUserResult}" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface IUserService : IService<IUserParameter, IUserResult>
    {
    }
}
