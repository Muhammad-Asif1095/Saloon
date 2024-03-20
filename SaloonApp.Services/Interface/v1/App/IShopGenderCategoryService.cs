using SaloonApp.DataViewModels.Request;
using SaloonApp.DataViewModels.Response;

namespace SaloonApp.Services.Interface.v1
{
    public interface IShopGenderCategoryService
    {
        Task<bool> ControllActivation(Guid id, Guid userId);
        Task<ListResponse<ShopCommonVM>> Get(ListGeneralModel page, Guid userId);
        Task<ShopCommonVM> GetEdit(Guid id, Guid userId);
        Task<bool> Save(ShopCommonVM request, Guid userId);
    }
}
