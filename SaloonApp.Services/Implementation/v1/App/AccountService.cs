using SaloonApp.Data.SaloonDB.DTO;
using SaloonApp.Data.SaloonDB;
using SaloonApp.DataViewModels.Common;
using SaloonApp.DataViewModels.Request;
using SaloonApp.DataViewModels.Response;
using SaloonApp.Services.Interface.v1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SaloonApp.Services.Implementation.v1.App
{
    public class AccountService : IAccountService
    {
        private readonly IConfiguration configuration;

        public AccountService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        #region Login/Signup
        public Tuple<AppLoginResponse, bool, bool, bool> AppLogin(AppLoginRequest request)
        {
            string encryptionKey = configuration.GetValue<string>("EncryptionKey"), tokenKey = configuration.GetValue<string>("Tokens:Key");

            try
            {
                var encryptedPassword = new Encryption().Encrypt(request.Password, encryptionKey);
                var response = new AppLoginResponse();
                bool isLogin = false,
                    isBlock = false,
                    isVerified = false;

                using (var db = new SaloonDbContext())
                {
                    var user = db.AspNetUsers
                        .Include(x => x.AdminUserRoles).FirstOrDefault(x => (request.UserInfo.Contains("@") ? x.Email.ToLower().Equals(request.UserInfo.ToLower()) : (x.PhoneCountryCode + x.PhoneNumber).Equals(request.UserInfo)) && x.Password.Equals(encryptedPassword));

                    if (user == null) return Tuple.Create(response, isLogin, isBlock, isVerified);
                    isBlock = user.IsBlocked;
                    if (isBlock) return Tuple.Create(response, isLogin, isBlock, isVerified);
                    isVerified = true;
                    if (!isVerified) return Tuple.Create(response, isLogin, isBlock, isVerified);

                    var authToken = new Encryption().GetToken(new AuthToken { UserId = user.Id, DeviceTypeId = request.DeviceType, DeviceToken = request.DeviceToken, RoleId = user.AdminUserRoles.FirstOrDefault(x => x.IsEnabled).RoleId }, user.Id, tokenKey);

                    var res = AddMobileInfo(user.Id, request.DeviceToken, request.DeviceType, request.DeviceModel, request.OS, request.Version);

                    if (!res) return Tuple.Create(response, isLogin, isBlock, isVerified);

                    response = new AppLoginResponse
                    {
                        AccessToken = authToken,
                        IsAccountVerified = true,
                        username = user.Name,
                    };
                    isLogin = true;

                    return Tuple.Create(response, isLogin, isBlock, isVerified);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Logout(Guid userId, string deviceToken, bool logoutFromAll)
        {
            try
            {
                bool res = false;
                using (var db = new SaloonDbContext())
                {
                    using (var comite = db.Database.BeginTransaction())
                    {
                        try
                        {
                            if (logoutFromAll)
                            {
                                db.UserDeviceInformations.Where(x => x.AppUserId.Equals(userId) && x.IsEnabled).ToList().ForEach(x => { x.IsEnabled = false; x.UpdatedOn = DateTime.Now; x.UpdatedBy = userId.ToString(); });
                                db.SaveChanges();
                                comite.Commit();
                                res = true;
                            }
                            else
                            {
                                var model = db.UserDeviceInformations.FirstOrDefault(x => x.AppUserId.Equals(userId) && x.DeviceToken.Equals(deviceToken));
                                if (model != null)
                                {
                                    model.IsEnabled = false;
                                    model.UpdatedOn = DateTime.Now;
                                    model.UpdatedBy = userId.ToString();

                                    db.Entry(model).State = EntityState.Modified;
                                    await db.SaveChangesAsync();
                                    comite.Commit();
                                    res = true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            comite.Rollback();
                            throw ex;
                        }
                    }
                }
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool AddMobileInfo(Guid userId, string deviceToken, int deviceType, string name, string versionName, string version)
        {
            bool result = false;
            try
            {
                using (var db = new SaloonDbContext())
                {
                    using (var trans = db.Database.BeginTransaction())
                    {
                        try
                        {
                            db.UserDeviceInformations.Where(x => x.AppUserId.Equals(userId) && x.IsEnabled).ToList().ForEach(x => { x.IsEnabled = false; x.UpdatedBy = userId.ToString(); x.UpdatedOn = DateTime.Now; });
                            db.SaveChanges();

                            db.UserDeviceInformations.Add(new UserDeviceInformations
                            {
                                Id = SystemGlobal.GetId(),
                                Name = name,
                                Version = version,
                                VersionName = versionName,
                                DeviceTypeId = deviceType,
                                DeviceToken = deviceToken,
                                AppUserId = userId,
                                IsEnabled = true,
                                CreatedBy = userId.ToString(),
                                CreatedOn = DateTime.Now,
                                CreatedOnDate = DateTime.Now,
                            });
                            db.SaveChanges();
                            trans.Commit();
                            result = true;
                        }
                        catch (Exception)
                        {
                            trans.Rollback();
                            result = false;
                        }
                    }

                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Authorization
        public bool IsTokenValid(Guid userId, string deviceToken)
        {
            try
            {
                using (var db = new SaloonDbContext())
                {
                    var model = db.UserDeviceInformations.FirstOrDefault(x => x.AppUserId.Equals(userId) && x.DeviceToken.Equals(deviceToken) && x.IsEnabled == true);
                    return model == null ? false : true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsAccountVerified(Guid userId)
        {
            try
            {
                bool res = false;

                using (var db = new SaloonDbContext())
                {
                    var model = db.AspNetUsers.FirstOrDefault(x => x.Id.Equals(userId));

                    if (model != null)
                    {
                        res = true;
                    }
                }

                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> IsAdminUserAllowed(Guid userId, Guid roleId, Guid rightId)
        {
            try
            {
                using (var db = new SaloonDbContext())
                {
                    var tenantID = Environment.GetEnvironmentVariable("TENANT_ID");

                    var isUserValid = db.AspNetUsers.Any(x => (x.IsActive ?? false) && x.Id.Equals(userId) && x.FkCustomerId.ToString().ToLower().Equals(tenantID.ToString().ToLower()));

                    if (!isUserValid) return false;

                    var isUserAuthorized = db.RoleRights.Any(x => x.IsEnabled && x.RoleId.Equals(roleId) && x.RightId.Equals(rightId));

                    if (!isUserAuthorized) return false;

                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
