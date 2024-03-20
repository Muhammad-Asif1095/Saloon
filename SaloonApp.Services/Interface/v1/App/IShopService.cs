using SaloonApp.Data.SaloonDB.DTO;
using SaloonApp.DataViewModels.Request;
using SaloonApp.DataViewModels.Response;

namespace SaloonApp.Services.Interface.v1
{
    public interface IShopService
    {
        Task<bool> ControllActivation(Guid id, Guid userId);
        Task<ListResponse<ShopVM>> Get(ListGeneralModel page, Guid userId);
        Task<ShopVM> GetEdit(Guid id, Guid userId);
        Task<bool> Save(ShopVM request, Guid userId);
    }
}
