using Saloon.DataViewModels.Request.Admin.v1;
using Saloon.DataViewModels.Response.Admin.v1;
using ListGeneralModel = Saloon.DataViewModels.Request.Admin.v1.ListGeneralModel;

namespace Saloon.Services.Interface.v1.App
{
    public interface IStaffService
    {
        Task<bool> ControllActivation(Guid id, Guid userId, bool isRecursive);
        Task<ListResponse<StaffVM>> Get(ListGeneralModel page, Guid userId);
        Task<StaffVM> GetEdit(Guid id, Guid userId);
        Task<bool> Save(StaffVM request, Guid userId);
    }
}
