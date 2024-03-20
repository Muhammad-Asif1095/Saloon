using Microsoft.EntityFrameworkCore;
using SaloonApp.Data.SaloonDB;
using SaloonApp.Data.SaloonDB.DTO;
using SaloonApp.DataViewModels.Common;
using SaloonApp.DataViewModels.Request;
using SaloonApp.DataViewModels.Response;
using SaloonApp.Services.Interface.v1;

namespace SaloonApp.Services.Implementation.v1.App
{
    public class StaffService : IStaffService
    {
        public async Task<bool> ControllActivation(Guid id, Guid userId, bool isRecursive)
        {
            try
            {
                bool response = false;
                using (var db = new SaloonDbContext())
                {
                    var model = await db.Staff.FirstOrDefaultAsync(x => x.Id.Equals(id));
                    if (model == null) throw new Exception("id Doesn't Exists");

                    model.IsDeleted = true;
                    model.DeletedOn = DateTime.Now;
                    model.DeletedBy = userId;

                    db.Entry(model).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    if (isRecursive)
                    {
                        var staffServices = await db.StaffServices.Where(x => x.StaffId.Equals(id)).Select(x => x.Id.ToString()).ToArrayAsync();
                        if (staffServices.Length > 0)
                        {
                            await db.Database.ExecuteSqlInterpolatedAsync($"Update StaffServices set IsDeleted=1, DeletedBy={userId}, DeletedOn={DateTime.Now} where StaffId = {id}");

                        }
                    }
                    response = true;

                }
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ListResponse<StaffVM>> Get(ListGeneralModel page, Guid userId)
        {
            try
            {
                ListResponse<StaffVM> response = new ListResponse<StaffVM>();

                using (var db = new SaloonDbContext())
                {

                    var query = db.Staff
                        .Where(x =>
                        !x.IsDeleted &&
                        (page.Id == null ? true : x.Id.Equals(page.Id))
                        )
                        .Select(x => new StaffVM
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Email = x.Email,
                            MobileNo = x.MobileNo,
                            Image = x.Image,
                            JobStartDate = x.JobStartDate,
                            Speciality = x.Speciality,
                            CreatedBy = x.CreatedBy,
                            CreatedByName = x.CreatedByNavigation.Name,
                            CreatedOn = x.CreatedOn,
                            Services = x.StaffServices.Select(y => new StaffServicesVM
                            {
                                Id = y.Service.Id,
                                Name = y.Service.Name
                            }).ToList()
                        }).ToList()
                        .AsQueryable();

                    if (!string.IsNullOrEmpty(page.Search))
                    {
                        var date = new DateTime();
                        var sdate = DateTime.TryParse(page.Search, out date);
                        int totalCases = -1;
                        var isNumber = int.TryParse(page.Search, out totalCases);

                        query = query.Where(
                        x => x.Name.ToLower().Contains(page.Search.ToLower()) || x.MobileNo.ToLower().Contains(page.Search.ToLower())
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
                    response.Data = orderedQuery.Skip(page.Page).Take(page.PageSize).ToList();
                    response.Search = page.Search;
                    response.SortBy = page.SortBy;

                }
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<StaffVM> GetEdit(Guid id, Guid userId)
        {
            try
            {
                using (var db = new SaloonDbContext())
                {
                    var staff = await db.Staff
                                .Where(x => x.Id.Equals(id))
                                .Select(x => new StaffVM
                                {
                                    Id = x.Id,
                                    Name = x.Name,
                                    Email = x.Email,
                                    MobileNo = x.MobileNo,
                                    Image = x.Image,
                                    JobStartDate = x.JobStartDate,
                                    Speciality = x.Speciality,
                                    CreatedBy = x.CreatedBy,
                                    CreatedByName = x.CreatedByNavigation.Name,
                                    CreatedOn = x.CreatedOn,
                                    Services = x.StaffServices.Select(y => new StaffServicesVM
                                    {
                                        Id = y.Service.Id,
                                        Name = y.Service.Name
                                    }).ToList()
                                }).FirstOrDefaultAsync();
                    return staff;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Save(StaffVM request, Guid userId)
        {
            try
            {
                bool response = false;

                if (request.Id.Equals(Guid.Empty))
                {
                    using (var db = new SaloonDbContext())
                    {
                        using (var trans = db.Database.BeginTransaction())
                        {
                            try
                            {
                                if (db.Staff.Any(x =>
                                !x.IsDeleted &&
                                (x.Name == request.Name)
                                ))
                                    throw new Exception("Duplicate Name");
                                Staff staff = new Staff
                                {
                                    Id = SystemGlobal.GetId(),
                                    Name = request.Name,
                                    Email = request.Email,
                                    MobileNo = request.MobileNo,
                                    JobStartDate = request.JobStartDate,
                                    Speciality = request.Speciality,
                                    CreatedBy = userId,
                                    CreatedOn = DateTime.Now
                                };
                                await db.Staff.AddAsync(staff);
                                await db.SaveChangesAsync();

                                var staffId = staff.Id;
                                if (request.Services.Count > 0)
                                {
                                    var servicesList = new List<StaffServices>();
                                    foreach (var service in request.Services)
                                    {
                                        StaffServices staffService = new StaffServices
                                        {
                                            Id = SystemGlobal.GetId(),
                                            ServiceId = service.Id,
                                            StaffId = staffId,
                                            CreatedBy = userId,
                                            CreatedOn = DateTime.Now,
                                        };
                                        servicesList.Add(staffService);
                                    }
                                    await db.StaffServices.AddRangeAsync(servicesList);
                                    await db.SaveChangesAsync();
                                }

                                trans.Commit();
                                //var notyMgr = new NotificationManager(userId, DateTime.Now, "Branch", request.Name);
                                //notyMgr.sendNotification(notyMgr.AddBranch);
                                response = true;
                            }
                            catch (Exception)
                            {
                                trans.Rollback();
                                throw;
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
                                if (db.Staff.Any(x =>
                               !x.IsDeleted &&
                               !x.Id.Equals(request.Id) &&
                               (x.Name == request.Name)
                               ))
                                    throw new Exception("Duplicate Name");

                                var model = db.Staff.FirstOrDefault(x => x.Id.Equals(request.Id));

                                model.Name = request.Name;
                                model.Email = request.Email;
                                model.MobileNo = request.MobileNo;
                                model.Speciality = request.Speciality;
                                model.ModifiedOn = DateTime.Now;
                                model.ModifiedBy = userId;

                                db.Entry(model).State = EntityState.Modified;
                                await db.SaveChangesAsync();


                                var staffServicesToRemove = db.StaffServices.Where(x => x.StaffId.Equals(request.Id)).ToList();
                                foreach (var service in staffServicesToRemove)
                                {
                                    service.IsDeleted = true;
                                    service.ModifiedBy = userId;
                                    service.ModifiedOn = DateTime.Now;

                                    db.Entry(service).State = EntityState.Modified;
                                    await db.SaveChangesAsync();
                                }
                                if (request.Services.Count > 0)
                                {
                                    var servicesList = new List<StaffServices>();
                                    foreach (var service in request.Services)
                                    {
                                        StaffServices staffService = new StaffServices
                                        {
                                            Id = SystemGlobal.GetId(),
                                            ServiceId = service.Id,
                                            StaffId = request.Id,
                                            CreatedBy = userId,
                                            CreatedOn = DateTime.Now,
                                        };
                                        servicesList.Add(staffService);
                                    }
                                    await db.StaffServices.AddRangeAsync(servicesList);
                                    await db.SaveChangesAsync();
                                }
                                trans.Commit();
                                //var notyMgr = new NotificationManager(userId, DateTime.Now, "Branch", request.Name);
                                //notyMgr.sendNotification(notyMgr.UpdateBranch);
                                response = true;
                            }
                            catch (Exception)
                            {
                                trans.Rollback();
                                throw;
                            }
                        }
                    }
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
