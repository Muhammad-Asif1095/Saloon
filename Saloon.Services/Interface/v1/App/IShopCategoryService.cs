using Saloon.DataViewModels.Request.Admin;
using Saloon.DataViewModels.Response.Admin.v1;
using ListGeneralModel = Saloon.DataViewModels.Request.Admin.v1.ListGeneralModel;

namespace Saloon.Services.Interface.v1.App
{
    public interface IShopCategoryService
    {
        Task<bool> ControllActivation(Guid id, Guid userId);
        Task<ListResponse<ShopCommonVM>> Get(ListGeneralModel page, Guid userId);
        Task<ShopCommonVM> GetEdit(Guid id, Guid userId);
        Task<bool> Save(ShopCommonVM request, Guid userId);
    }
}
