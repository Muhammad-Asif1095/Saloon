using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Saloon.DataViewModels.Common;
using Saloon.DataViewModels.Request;
using Saloon.DataViewModels.Request.Admin.v1;
using Saloon.DataViewModels.Response;
using Saloon.DataViewModels.Response.Admin.v1;

namespace Saloon.Services.Interface.v1.Admin
{
    public interface IAccountService
    {
        Tuple<AdminLoginResponse, bool, bool> AdminLogin(AdminLoginRequest request);
        Task<bool> AddRole(string name, Guid userId);
        Task<bool> UpdateRole(UpdateRoleRequest roleRequest, Guid userId);
        Task<bool> ControllRoleActivation(Guid roleId, bool activation, Guid userId);
        List<General<Guid>> GetRoles();
        Task<List<General<Guid>>> GetRights(Guid UserId);
        List<General<Guid>> GetRoleRights(Guid roleId);
        Task<bool> AssignRights(AssignRight assignRight, Guid userId);
        GetUsersResponse GetUsers(GetUsersRequestVM page, Guid userId);
        Task<bool> SaveUser(CreateUserRequest createUser, Guid userId);
        CreateUserRequest GetEditUser(Guid userId);
        Task<bool> ControllUserActivation(Guid adminUserId, bool activation, bool isRemove, Guid userId);
        Task<bool> ChangePassword(AdminChangePasswordRequest changePassword, Guid userId);
        Task<bool> IsAdminUserAllowed(Guid userId, Guid roleId, Guid rightId);
        Task<List<NotificationsVM>> Notifications();
        Task<List<NotificationsSubscriptionVM>> UserNotifications(Guid UserId);
        Task<bool> UpdateUserNotifications(Guid UserId, List<Guid> RequestNotifications);
        Task<ListResponse<RolesRightsResponseVM>> GetRolesRights(Saloon.DataViewModels.Request.Admin.v1.ListGeneralModel page, Guid userId);
        Task<RolesRightsManagement> GetRolesRight(Guid UserId, Guid roleId);
        Task<bool> AddRolesRights(Guid UserId, RolesRightsManagement requestRole);
        Task<bool> UpdateRolesRights(Guid UserId, RolesRightsManagement requestRole);
        Task<bool> DeleteRolesRights(Guid UserId, Guid roleId);
        Task<string> SendEmailVerfication(Guid UserID);
        Task<string> VerifyEmail(Guid UserID, string Secret);
    }
}
