using System;
using System.Threading.Tasks;
using Saloon.DataViewModels.Request;
using Saloon.DataViewModels.Response;

namespace Saloon.Services.Interface.v1.App
{
    public interface IAccountService
    {
        Tuple<AppLoginResponse, bool, bool, bool> AppLogin(AppLoginRequest request);
        Task<bool> Logout(Guid userId, string deviceToken, bool logoutFromAll);
        bool IsTokenValid(Guid userId, string deviceToken);
        bool IsAccountVerified(Guid userId);
    }
}
