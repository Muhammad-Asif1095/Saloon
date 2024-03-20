using SaloonApp.DataViewModels.Request;
using SaloonApp.DataViewModels.Response;

namespace SaloonApp.Services.Interface.v1
{
    public interface IAccountService
    {
        Tuple<AppLoginResponse, bool, bool, bool> AppLogin(AppLoginRequest request);
        Task<bool> Logout(Guid userId, string deviceToken, bool logoutFromAll);
        bool IsTokenValid(Guid userId, string deviceToken);
        bool IsAccountVerified(Guid userId);
        Task<bool> IsAdminUserAllowed(Guid userId, Guid roleId, Guid rightId);
    }
}
