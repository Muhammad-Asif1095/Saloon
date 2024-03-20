using Saloon.DataViewModels.Request.Admin.v1;
using Saloon.DataViewModels.Response.Admin.v1;
using System.Threading.Tasks;
using ListGeneralModel = Saloon.DataViewModels.Request.Admin.v1.ListGeneralModel;

namespace Saloon.Services.Interface.v1.App
{
    public interface IShopService
    {
        Task<bool> ControllActivation(Guid id, Guid userId);
        Task<ListResponse<ShopVM>> Get(ListGeneralModel page, Guid userId);
        Task<ShopVM> GetEdit(Guid id, Guid userId);
        Task<bool> Save(ShopVM request, Guid userId);
    }
}
