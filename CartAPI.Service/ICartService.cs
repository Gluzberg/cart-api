using CartAPI.Service.Parameters;
using CartAPI.Service.Result;
using CartAPI.Service.Services.Base;

namespace CartAPI.Service
{
    /// <summary>
    /// ICartService
    /// </summary>
    /// <seealso cref="Services.Base.IService{ICartParameter, ICartResult}" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface ICartService : IService<ICartParameter, ICartResult>
    {

    }
}
