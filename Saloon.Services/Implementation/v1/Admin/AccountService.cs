using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Saloon.Common;
using Saloon.Data.Context;
using Saloon.DataViewModels.Common;
using Saloon.DataViewModels.Request;
using Saloon.DataViewModels.Response;
using Saloon.Services.Interface.v1.Admin;
using Saloon.DataViewModels.DTOs;
using Saloon.DataViewModels.Enum.Admin.v1;
using Saloon.DataViewModels.Request.Admin.v1;
using Saloon.DataViewModels.Response.Admin.v1;

namespace Saloon.Services.Implementation.v1.Admin
{
    public class AccountService : IAccountService
    {
        private readonly IConfiguration configuration;

        public AccountService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        #region Login
        public Tuple<AdminLoginResponse, bool, bool> AdminLogin(AdminLoginRequest request)
        {
            string encryptionKey = configuration.GetValue<string>("EncryptionKey"), tokenKey = configuration.GetValue<string>("Tokens:Key");

            try
            {
                var encryptedPassword = new Encryption().Encrypt(request.Password, encryptionKey);
                var response = new AdminLoginResponse();
                bool isLogin = false,
                    isBlock = false;

                using (var db = new SaloonDbContext())
                {
                    var user = db.AspNetUsers
                        .Include(x => x.AdminUserRoles).FirstOrDefault(x => x.Email.ToLower().Equals(request.UserInfo.ToLower()) && x.Password.Equals(encryptedPassword));

                    if (user == null) return Tuple.Create(response, isLogin, isBlock);
                    isBlock = user.IsBlocked;
                    if (isBlock) return Tuple.Create(response, isLogin, isBlock);

                    var authToken = new Encryption().GetToken(new AuthToken { UserId = user.Id, DeviceTypeId = (int)EDeviceType.Web, RoleId = user.AdminUserRoles.FirstOrDefault(x => x.IsEnabled).RoleId, DeviceToken = "" }, user.Id, tokenKey);

                    response = new AdminLoginResponse
                    {
                        AccessToken = authToken,
                        username = user.Name,
                    };
                    isLogin = true;
                    return Tuple.Create(response, isLogin, isBlock);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Dashboard Management
        #region Roles Rights Management
        public async Task<bool> AddRole(string name, Guid userId)
        {
            try
            {
                bool response = false;

                using (var db = new SaloonDbContext())
                {
                    if (db.Roles.Any(x => x.Name.ToLower().Equals(name.ToLower()))) throw new Exception("Role Already Exists");

                    await db.Roles.AddAsync(new Roles
                    {
                        Id = SystemGlobal.GetId(),
                        Name = name,
                        IsEnabled = true,
                        CreatedBy = userId,
                        CreatedOn = DateTime.Now,
                        CreatedOnDate = DateTime.Now
                    });
                    await db.SaveChangesAsync();

                    response = true;
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateRole(UpdateRoleRequest roleRequest, Guid userId)
        {
            try
            {
                bool response = false;

                using (var db = new SaloonDbContext())
                {
                    var role = db.Roles.FirstOrDefault(x => x.Id.Equals(roleRequest.Id) && x.IsEnabled);

                    if (role == null) throw new Exception("Role Id Doesn't Exists");

                    role.Name = roleRequest.Name;
                    role.UpdatedBy = userId.ToString();
                    role.UpdatedOn = DateTime.Now;

                    db.Entry(role).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    response = true;
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ControllRoleActivation(Guid roleId, bool activation, Guid userId)
        {
            try
            {
                bool response = false;

                using (var db = new SaloonDbContext())
                {
                    var role = db.Roles.FirstOrDefault(x => x.Id.Equals(roleId) && x.IsEnabled);

                    if (role == null) throw new Exception("Role Id Doesn't Exists");

                    role.IsEnabled = activation;
                    role.UpdatedBy = userId.ToString();
                    role.UpdatedOn = DateTime.Now;

                    db.Entry(role).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    response = true;
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<General<Guid>> GetRoles()
        {
            try
            {
                using (var db = new SaloonDbContext())
                {

                    return db.Roles.Where(x => x.IsEnabled).Select(x => new General<Guid>
                    {
                        Id = x.Id,
                        Name = x.Name
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<General<Guid>>> GetRights(Guid UserId)
        {
            try
            {
                var isSuperAdmin = await IsSuperAdmin(UserId);
                using (var db = new SaloonDbContext())
                {
                    if (isSuperAdmin)
                        return db.Rights.Where(x => x.IsEnabled).Select(x => new General<Guid>
                        {
                            Id = x.Id,
                            Name = x.Name
                        }).ToList();

                    var userRole = await db.AdminUserRoles
                        .Include(x => x.Role).ThenInclude(x => x.RoleRights).ThenInclude(x => x.Right)
                        .Where(x => x.IsEnabled && x.AdminUserId.ToString().ToLower().Equals(UserId.ToString().ToLower()))
                        .FirstOrDefaultAsync();

                    return userRole.Role.RoleRights.Select(x => new General<Guid>
                    {
                        Id = x.Right.Id,
                        Name = x.Right.Name
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<General<Guid>> GetRoleRights(Guid roleId)
        {
            try
            {
                using (var db = new SaloonDbContext())
                {
                    return db.RoleRights
                        .Include(x => x.Right)
                        .Where(x => x.RoleId.Equals(roleId) && x.IsEnabled).Select(x => new General<Guid>
                        {
                            Id = x.Right.Id,
                            Name = x.Right.Name
                        }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AssignRights(AssignRight assignRight, Guid userId)
        {
            try
            {
                List<RoleRights> rights = new List<RoleRights>();
                bool response = false;

                foreach (var rightId in assignRight.RightIds)
                {
                    rights.Add(new RoleRights
                    {
                        Id = SystemGlobal.GetId(),
                        RoleId = assignRight.RoleId,
                        RightId = rightId,
                        IsEnabled = true,
                        CreatedBy = userId.ToString(),
                        CreatedOn = DateTime.Now,
                        CreatedOnDate = DateTime.Now
                    });
                }

                using (var db = new SaloonDbContext())
                {
                    using (var trans = db.Database.BeginTransaction())
                    {
                        try
                        {
                            //remove Older One
                            await db.RoleRights.Where(x => x.RoleId.Equals(assignRight.RoleId) && x.IsEnabled).ForEachAsync(x => { x.IsEnabled = false; x.DeletedBy = userId.ToString(); x.DeletedOn = DateTime.Now; });
                            await db.SaveChangesAsync();

                            //Add new
                            await db.RoleRights.AddRangeAsync(rights);
                            await db.SaveChangesAsync();

                            trans.Commit();
                            response = true;
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            throw ex;
                        }
                    }
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region User Management 
        public GetUsersResponse GetUsers(GetUsersRequestVM page, Guid userId)
        {
            try
            {
                GetUsersResponse response = new GetUsersResponse();

                using (var db = new SaloonDbContext())
                {
                    var customerId = db.AspNetUsers.Find(userId)?.FkCustomerId;

                    var query = db.AspNetUsers
                        .Include(x => x.AdminUserRoles)
                        .Where(x =>
                        (x.IsActive ?? false) &&
                        (page.Id == null ? true : x.Id.Equals(page.Id)) &&
                        (customerId == null ? true : x.FkCustomerId.Equals(customerId)))
                        .Select(x => new CreateUserRequest
                        {
                            Id = x.Id,
                            Name = x.Name,
                            CountryCode = x.PhoneCountryCode,
                            PhoneNumber = x.PhoneNumber,
                            Email = x.Email,
                            Password = "***********",
                            CustomerId = x.FkCustomerId,
                            RoleId = x.AdminUserRoles.FirstOrDefault(y => y.IsEnabled).RoleId,
                            RoleName = x.AdminUserRoles.FirstOrDefault(y => y.IsEnabled).Role.Name
                            //ProfileImage = new FileUrlResponce
                            //{
                            //    URL = x.ImageMedia.MediaUri,
                            //    ThumbnailUrl = x.ImageThumbnailMedia.MediaUri
                            //}
                        })
                      .AsQueryable();

                    if (!string.IsNullOrEmpty(page.Search))
                    {
                        var date = new DateTime();
                        var sdate = DateTime.TryParse(page.Search, out date);
                        int totalCases = -1;
                        var isNumber = Int32.TryParse(page.Search, out totalCases);

                        query = query.Where(
                        x => x.Name.ToLower().Contains(page.Search.ToLower())
                    );
                    }

                    var orderedQuery = query;
                    foreach (var sortColumn in page.SortBy)
                    {
                        orderedQuery = SortExtension.OrderByDynamic(query, sortColumn.Name, sortColumn.Direction == "desc");
                    }


                    response.Page = page.Page;
                    response.PageSize = page.PageSize;
                    response.TotalRecords = orderedQuery.Count();
                    response.Users = orderedQuery.Skip(page.Page).Take(page.PageSize).ToList();
                    response.Search = page.Search;
                    response.SortBy = page.SortBy;
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> SaveUser(CreateUserRequest createUser, Guid userId)
        {
            try
            {
                bool response = false;

                if (createUser.Id == null)
                {
                    var encryptedPassword = new Encryption().Encrypt(createUser.Password, configuration.GetValue<string>("EncryptionKey"));

                    using (var db = new SaloonDbContext())
                    {
                        if (db.AspNetUsers.Any(x => x.Email.ToLower().Equals(createUser.Email.ToLower()))) throw new Exception("Email Already Exists");

                        using (var trans = db.Database.BeginTransaction())
                        {
                            try
                            {
                                AspNetUsers user = new AspNetUsers
                                {
                                    Id = SystemGlobal.GetId(),
                                    Name = createUser.Name,
                                    Email = createUser.Email,
                                    Password = encryptedPassword,
                                    PhoneCountryCode = createUser.CountryCode,
                                    PhoneNumber = createUser.PhoneNumber,
                                    FkCustomerId = createUser.CustomerId,
                                    BirthDate = createUser.BirthDate,
                                    Age = createUser.Age,
                                    IsMale = createUser.IsMale,
                                    IsBlocked = false,
                                    IsActive = true,
                                    CreatedBy = SystemGlobal.GetId(),
                                    CreatedDate = DateTime.Now
                                };
                                await db.AspNetUsers.AddAsync(user);
                                await db.SaveChangesAsync();
                                 
                                trans.Commit();

                                response = true;
                            }
                            catch (Exception ex)
                            {
                                trans.Rollback();
                                throw ex;
                            }
                        }
                    }
                }
                else
                {
                    using (var db = new SaloonDbContext())
                    {
                        using (var trans = db.Database.BeginTransaction())
                        {
                            try
                            {
                                var user = db.AspNetUsers.Find(createUser.Id);

                                if (user == null) throw new Exception("User Not Found");

                                //delete Old One
                                await db.AdminUserRoles.Where(x => x.IsEnabled && x.AdminUserId.Equals(user.Id)).ForEachAsync(x => { x.IsEnabled = false; x.DeletedBy = userId.ToString(); x.DeletedOn = DateTime.Now; });
                                await db.SaveChangesAsync();

                                user.Name = createUser.Name;
                                user.Email = createUser.Email;
                                user.PhoneCountryCode = createUser.CountryCode;
                                user.PhoneNumber = createUser.PhoneNumber;
                                user.FkCustomerId = createUser.CustomerId;
                                user.Age = createUser.Age;
                                user.BirthDate= DateTime.Now;
                                user.IsMale = createUser.IsMale;
                                user.UpdatedDate = DateTime.Now;
                                user.UserTypeId = createUser.UserTypeId;

                                db.Entry(user).State = EntityState.Modified;
                                await db.SaveChangesAsync();

                                trans.Commit();

                                response = true;
                            }
                            catch (Exception ex)
                            {
                                trans.Rollback();
                                throw ex;
                            }
                        }
                    }
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CreateUserRequest GetEditUser(Guid userId)
        {
            try
            {
                using (var db = new SaloonDbContext())
                {
                    return db.AspNetUsers
                        .Include(x => x.AdminUserRoles)
                        .Where(x => x.Id.Equals(userId))
                        .Select(x => new CreateUserRequest
                        {
                            Id = x.Id,
                            Name = x.Name,
                            CountryCode = x.PhoneCountryCode,
                            PhoneNumber = x.PhoneNumber,
                            CustomerId = x.FkCustomerId,
                            Email = x.Email,
                            Password = "***********",
                            RoleId = x.AdminUserRoles.FirstOrDefault(y => y.IsEnabled).RoleId,
                            RoleName = x.AdminUserRoles.FirstOrDefault(y => y.IsEnabled).Role.Name,
                            //ProfileImage = new FileUrlResponce
                            //{
                            //    ImageMediaId = x.ImageMediaId,
                            //    ImageThumbnailMediaId = x.ImageThumbnailMediaId,
                            //    URL = x.ImageMedia.MediaUri,
                            //    ThumbnailUrl = x.ImageThumbnailMedia.MediaUri
                            //}
                        })
                        .FirstOrDefault() ?? throw new Exception("User Not Found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ControllUserActivation(Guid adminUserId, bool activation, bool isRemove, Guid userId)
        {
            try
            {
                bool response = false;

                using (var db = new SaloonDbContext())
                {
                    var user = db.AspNetUsers.FirstOrDefault(x => x.Id.Equals(adminUserId) && (x.IsActive ?? false));

                    if (user == null) throw new Exception("user Id Doesn't Exists");

                    if (isRemove)
                    {
                        user.IsActive = activation;
                    }
                    else
                    {
                        user.IsBlocked = activation;
                    }

                    user.UpdatedBy = userId;
                    user.UpdatedDate = DateTime.Now;

                    db.Entry(user).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    response = true;
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ChangePassword(AdminChangePasswordRequest changePassword, Guid userId)
        {
            try
            {
                string encryptionKey = configuration.GetValue<string>("EncryptionKey");
                bool response = false;

                //var encryptedPassword = new Encryption().Encrypt(changePassword.OldPassword, encryptionKey);

                using (var db = new SaloonDbContext())
                {
                    //var user = db.AspNetUsers.FirstOrDefault(x => x.Id.Equals(changePassword.UserId) && x.Password.Equals(encryptedPassword));
                    var user = db.AspNetUsers.FirstOrDefault(x => x.Id.Equals(changePassword.UserId));

                    if (user == null) throw new Exception("user Doesn't Exists");

                    user.Password = new Encryption().Encrypt(changePassword.NewPassword, encryptionKey);
                    user.UpdatedDate = DateTime.Now;
                    user.UpdatedBy = userId;

                    db.Entry(user).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    response = true;
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

        #region Authorization
        public async Task<bool> IsAdminUserAllowed(Guid userId, Guid roleId, Guid rightId)
        {
            try
            {
                using (var db = new SaloonDbContext())
                {
                    var isUserValid = db.AspNetUsers.Any(x => (x.IsActive ?? false) && x.Id.Equals(userId));

                    if (!isUserValid) return false;

                    var isUserAuthorized = db.RoleRights.Any(x => x.IsEnabled && x.RoleId.Equals(roleId) && x.RightId.Equals(rightId));

                    if (!isUserAuthorized) return false;

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> IsSuperAdmin(Guid userId)
        {
            try
            {
                using (var db = new SaloonDbContext())
                {
                    return await db.AdminUserRoles
                        .AnyAsync(x =>
                            x.IsEnabled &&
                            // Super Admin ID
                            x.RoleId.ToString().ToLower().Equals("5BB20BF7-30FE-473F-8967-478F1F18C5D0".ToString().ToLower()) &&
                            x.AdminUserId.ToString().ToLower().Equals(userId.ToString().ToLower())
                            );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region Notifications

        public async Task<List<NotificationsVM>> Notifications()
        {
            try
            {

                using (var db = new SaloonDbContext())
                {
                    return await db.Notifications.Select(x => new NotificationsVM { Id = x.Id, Name = x.Name }).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<NotificationsSubscriptionVM>> UserNotifications(Guid UserId)
        {
            try
            {

                using (var db = new SaloonDbContext())
                {
                    return await db.NotificationsSubscription
                      .Where(x => x.AspNetUsersId.ToString().ToLower().Equals(UserId.ToString().ToLower()))
                      .Select(x => new NotificationsSubscriptionVM { Id = x.Id, AspNetUsersId = x.AspNetUsersId, NotificationsId = x.NotificationsId })
                      .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateUserNotifications(Guid UserId, List<Guid> RequestNotifications)
        {
            try
            {

                using (var db = new SaloonDbContext())
                {
                    var old = await db.NotificationsSubscription.Where(x => x.AspNetUsersId.ToString().ToLower().Equals(UserId.ToString().ToLower())).ToListAsync();
                    db.NotificationsSubscription.RemoveRange(old);
                    await db.SaveChangesAsync();

                    var newNoty = new List<NotificationsSubscription>();
                    RequestNotifications.ForEach(x => newNoty.Add(new NotificationsSubscription { AspNetUsersId = UserId, NotificationsId = x }));
                    await db.NotificationsSubscription.AddRangeAsync(newNoty);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region Roles Rights Management

        public async Task<ListResponse<RolesRightsResponseVM>> GetRolesRights(Saloon.DataViewModels.Request.Admin.v1.ListGeneralModel page, Guid userId)
        {

            try
            {
                var response = new ListResponse<RolesRightsResponseVM>();

                using (var db = new SaloonDbContext())
                {
                    var customerId = db.AspNetUsers.Find(userId).FkCustomerId;
                    //var appRights = await db.Rights.ToListAsync();

                    var query = db.Roles
                        .Include(x => x.RoleRights)
                        .ThenInclude(x => x.Right)
                        .Where(x =>
                        x.CreatedByNavigation.FkCustomerId.ToString().ToLower().Equals(customerId.ToString().ToLower()) &&
                        x.IsEnabled &&
                        x.CreatedBy.ToString().ToLower().Equals(userId.ToString().ToLower())
                        )
                        .Select(role => new RolesRightsResponseVM
                        {
                            Id = role.Id,
                            Name = role.Name,
                            CreatedOn = role.CreatedOn,
                            CreatedByName =role.CreatedByNavigation.Name,
                            Rights = role.RoleRights.Select(rght => new RolesRightsManagementRight
                            {
                                Id = rght.Id,
                                Name = rght.Right.Name,
                                RightId = rght.RightId,
                                Granted = true,
                                CreatedBy =role.CreatedByNavigation.Name,
                            }).ToList()
                        })
                        .AsQueryable();

                    if (!string.IsNullOrEmpty(page.Search))
                    {
                        var date = new DateTime();
                        var sdate = DateTime.TryParse(page.Search, out date);
                        int totalCases = -1;
                        var isNumber = Int32.TryParse(page.Search, out totalCases);

                        query = query.Where(x => x.Name.ToLower().Contains(page.Search.ToLower()));
                    }

                    var orderedQuery = query;
                    foreach (var sortColumn in page.SortBy)
                    {
                        orderedQuery = SortExtension.OrderByDynamic(query, sortColumn.Name, sortColumn.Direction == "asc");
                    }

                    var data = await orderedQuery.Skip(page.Page).Take(page.PageSize).ToListAsync();

                    //data.ForEach(r =>
                    //{

                    //    var rightIds = r.Rights.Select(x => x.Id.ToString().ToLower()).ToList();

                    //    appRights
                    //    .Where(appright => !rightIds.Contains(appright.Id.ToString().ToLower())).ToList()
                    //    .ForEach(ungrantedRight =>
                    //    {
                    //        r.Rights.Add(new RolesRightsManagementRight
                    //        {
                    //            Id = ungrantedRight.Id,
                    //            Name = ungrantedRight.Name,
                    //            Granted = false,
                    //        });
                    //    });

                    //});


                    response.Page = page.Page;
                    response.PageSize = page.PageSize;
                    response.TotalRecords = orderedQuery.Count();
                    response.Data = data;
                    response.Search = page.Search;
                    response.SortBy = page.SortBy;
                }
                return response;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RolesRightsManagement> GetRolesRight(Guid UserId, Guid roleId)
        {

            try
            {

                using (var db = new SaloonDbContext())
                {
                    var customerId = (await db.AspNetUsers.FindAsync(UserId)).FkCustomerId;
                    var appRights = await db.Rights.ToListAsync();

                    var roles = await db.Roles
                        .Include(x => x.RoleRights)
                        .ThenInclude(x => x.Right)
                        .Where(x => x.Id.ToString().ToLower().Equals(roleId.ToString().ToLower()) && x.IsEnabled)
                        .Select(role => new RolesRightsManagement
                        {
                            Id = role.Id,
                            Name = role.Name,
                            Rights = role.RoleRights.Select(rght => new RolesRightsManagementRight
                            {
                                Id = rght.Id,
                                RightId = rght.RightId,
                                Name = rght.Right.Name,
                                Granted = true,
                            }).ToList()
                        })
                        .FirstOrDefaultAsync();

                    //var rightIds = roles.Rights.Select(x => x.Id.ToString().ToLower()).ToList();

                    //appRights
                    //.Where(appright => !rightIds.Contains(appright.Id.ToString().ToLower())).ToList()
                    //.ForEach(ungrantedRight =>
                    //{
                    //    roles.Rights.Add(new RolesRightsManagementRight
                    //    {
                    //        Id = ungrantedRight.Id,
                    //        Name = ungrantedRight.Name,
                    //        Granted = false,
                    //    });
                    //});

                    return roles;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> AddRolesRights(Guid UserId, RolesRightsManagement requestRole)
        {

            try
            {

                using (var db = new SaloonDbContext())
                {

                    if (db.Roles.Any(x =>
                              x.IsEnabled &&
                              x.CreatedByNavigation.FkCustomerId.Equals(db.AspNetUsers.Find(UserId).FkCustomerId) &&
                              (x.Name.ToLower() == requestRole.Name.ToLower())
                              ))
                        throw new Exception("Duplicate Name");

                    var newRoleId = SystemGlobal.GetId();
                    await db.Roles.AddAsync(new Roles
                    {
                        Id = newRoleId,
                        Name = requestRole.Name,
                        CreatedBy = UserId,
                        CreatedOn = DateTime.Now,
                        IsEnabled = true,
                        
                    });

                    await db.SaveChangesAsync();

                    var rights = new List<RoleRights>();

                    requestRole.Rights.ForEach(x =>
                    {

                        rights.Add(new RoleRights
                        {

                            Id = SystemGlobal.GetId(),
                            RoleId = newRoleId,
                            RightId = x.RightId,
                            CreatedBy = UserId.ToString(),
                            CreatedOn = DateTime.Now,
                            IsEnabled = true,
                        });

                    });

                    await db.RoleRights.AddRangeAsync(rights);
                    await db.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateRolesRights(Guid UserId, RolesRightsManagement requestRole)
        {

            try
            {

                using (var db = new SaloonDbContext())
                {

                    var role = await db.Roles.
                        Where(x => x.Id.ToString().ToLower().Equals(requestRole.Id.ToString().ToLower()) && x.IsEnabled)
                        .FirstOrDefaultAsync();
                    role.Name = requestRole.Name;
                    role.UpdatedBy = UserId.ToString();
                    role.UpdatedOn = DateTime.Now;
                    await db.SaveChangesAsync();

                    var oldRolesRights = await db.RoleRights
                        .Where(x => x.RoleId.ToString().ToLower().Equals(requestRole.Id.ToString().ToLower()))
                        .ToListAsync();
                    db.RoleRights.RemoveRange(oldRolesRights);
                    await db.SaveChangesAsync();

                    var rights = new List<RoleRights>();
                    requestRole.Rights.ForEach(x =>
                    {

                        rights.Add(new RoleRights
                        {

                            Id = SystemGlobal.GetId(),
                            RoleId = requestRole.Id,
                            RightId = x.RightId,
                            CreatedBy = UserId.ToString(),
                            IsEnabled = true,
                            CreatedOn = DateTime.Now,
                        });

                    });
                    await db.RoleRights.AddRangeAsync(rights);

                    await db.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteRolesRights(Guid UserId, Guid roleId)
        {

            try
            {

                using (var db = new SaloonDbContext())
                {

                    var role = await db.Roles.
                        Where(x => x.Id.ToString().ToLower().Equals(roleId.ToString().ToLower()) && x.IsEnabled)
                        .FirstOrDefaultAsync();
                    role.IsEnabled = false;
                    role.DeletedBy = UserId.ToString();
                    role.DeletedOn = DateTime.Now;

                    await db.SaveChangesAsync();

                    var oldRolesRights = await db.RoleRights
                        .Where(x => x.RoleId.ToString().ToLower().Equals(roleId.ToString().ToLower()))
                        .ToListAsync();
                    db.RoleRights.RemoveRange(oldRolesRights);
                    await db.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Email Verification

        public async Task<string> SendEmailVerfication(Guid UserID) {

            try
            {

                using (var db = new SaloonDbContext())
                {

                    //var user = await db.AspNetUsers.FirstOrDefaultAsync(x => x.IsBlocked != true && x.IsActive == true && !x.isEmailVeified && x.Id.ToString().ToLower().Equals(UserID.ToString().ToLower()));
                    //if (user == null) throw new Exception("Invalid user");

                    //string secret = new Random().Next(0, 1000000).ToString("D6");

                    //user.EmailVerifyCode = secret;
                    //user.EmailVerifyCodeExpiry = DateTime.Now.AddMinutes(15);

                    //await db.SaveChangesAsync();

                    //var fromEmail = CommonAppConfig.GetKey("VerifyEmail");
                    //var fromEmailPassword = CommonAppConfig.GetKey("VerifyEmailPassword");
                    //var subject = "TPM - Email Verification";
                    //var body = $"An email verification request has been generated for the account {user.Email} at Saloon. Your 6 digit verification code is {secret}";
                    //await new SendEmail().Send(subject, body, user.Email, fromEmail, fromEmailPassword);

                    return "success";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<string> VerifyEmail(Guid UserID, string Secret)
        {

            try
            {

                //using (var db = new SaloonDbContext())
                //{

                //    var user = await db.AspNetUsers.FirstOrDefaultAsync(x =>
                //                                    x.IsBlocked != true &&
                //                                    x.IsActive == true &&
                //                                    !x.isEmailVeified &&
                //                                    x.Id.ToString().ToLower().Equals(UserID.ToString().ToLower()) &&
                //                                    x.EmailVerifyCode == Secret &&
                //                                    x.EmailVerifyCodeExpiry > DateTime.Now
                //                                    );
                //    if (user == null) throw new Exception("Invalid or Expired Code. Please regenerate the code and try again. Thank you.");

                //    string secret = new Random().Next(0, 1000000).ToString("D6");

                //    user.EmailVerifyCode = null;
                //    user.EmailVerifyCodeExpiry = null;
                //    user.isEmailVeified = true;

                //    await db.SaveChangesAsync();

                    return "Success";
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion


    }
}
