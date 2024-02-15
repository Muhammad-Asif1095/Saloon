using Microsoft.EntityFrameworkCore;
using Saloon.Common;
using Saloon.Data.Context;
using Saloon.DataViewModels.DTOs;
using Saloon.DataViewModels.Request.Admin;
using Saloon.DataViewModels.Response.Admin.v1;
using Saloon.Services.Interface.v1.App;
using ListGeneralModel = Saloon.DataViewModels.Request.Admin.v1.ListGeneralModel;

namespace Saloon.Services.Implementation.v1.App
{
    public class ShopGenderCategoryService : IShopGenderCategoryService
    {
        public async Task<ListResponse<ShopCommonVM>> Get(ListGeneralModel page, Guid userId)
        {
            try
            {
                ListResponse<ShopCommonVM> response = new ListResponse<ShopCommonVM>();

                using (var db = new SaloonDbContext())
                {

                    var query = db.ShopGenderCategory
                        .Where(x =>
                        !x.IsDeleted &&
                        (page.Id == null ? true : x.Id.Equals(page.Id))
                        )
                        .Select(x => new ShopCommonVM
                        {
                            Id = x.Id,
                            Name = x.Name,
                            CreatedBy = x.CreatedBy,
                            CreatedByName = x.CreatedByNavigation.Name,
                            CreatedOn = x.CreatedOn
                        }).ToList()
                        .AsQueryable();

                    if (!string.IsNullOrEmpty(page.Search))
                    {
                        var date = new DateTime();
                        var sdate = DateTime.TryParse(page.Search, out date);
                        int totalCases = -1;
                        var isNumber = int.TryParse(page.Search, out totalCases);

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

        public async Task<bool> Save(ShopCommonVM request, Guid userId)
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
                                if (db.ShopGenderCategory.Any(x =>
                                !x.IsDeleted &&
                                (x.Name == request.Name)
                                ))
                                    throw new Exception("Duplicate Name");
                                ShopGenderCategory shop = new ShopGenderCategory
                                {
                                    Id = SystemGlobal.GetId(),
                                    Name = request.Name,
                                    CreatedBy = userId,
                                    CreatedOn = DateTime.Now
                                };
                                await db.ShopGenderCategory.AddAsync(shop);
                                await db.SaveChangesAsync();

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
                                if (db.ShopGenderCategory.Any(x =>
                               !x.IsDeleted &&
                               !x.Id.Equals(request.Id) &&
                               (x.Name == request.Name)
                               ))
                                    throw new Exception("Duplicate Name or code");

                                var model = db.ShopGenderCategory.FirstOrDefault(x => x.Id.Equals(request.Id));

                                model.Name = request.Name;
                                model.ModifiedOn = DateTime.Now;
                                model.ModifiedBy = userId;

                                db.Entry(model).State = EntityState.Modified;
                                await db.SaveChangesAsync();

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

        public async Task<ShopCommonVM> GetEdit(Guid id, Guid userId)
        {
            try
            {
                using (var db = new SaloonDbContext())
                {
                    var shop = await db.ShopGenderCategory
                        .Where(x => x.Id.Equals(id))
                        .Select(x => new ShopCommonVM
                        {
                            Id = x.Id,
                            Name = x.Name,
                            CreatedBy = x.CreatedBy,
                            CreatedByName = x.CreatedByNavigation.Name,
                            CreatedOn = x.CreatedOn
                        })
                      .FirstOrDefaultAsync();


                    return shop;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ControllActivation(Guid id, Guid userId)
        {
            try
            {
                bool response = false;

                using (var db = new SaloonDbContext())
                {
                    var model = db.ShopGenderCategory.FirstOrDefault(x => x.Id.Equals(id));

                    if (model == null) throw new Exception("id Doesn't Exists");

                    model.IsDeleted = true;
                    model.DeletedOn = DateTime.Now;
                    model.DeletedBy = userId;

                    db.Entry(model).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    //var notyMgr = new NotificationManager(userId, DateTime.Now, "Branch", model.Name);
                    //notyMgr.sendNotification(notyMgr.DeleteBranch);
                    response = true;
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
