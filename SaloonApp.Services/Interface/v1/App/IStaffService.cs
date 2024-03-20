using SaloonApp.DataViewModels.Request;
using SaloonApp.DataViewModels.Response;

namespace SaloonApp.Services.Interface.v1
{
    public interface IStaffService
    {
        Task<bool> ControllActivation(Guid id, Guid userId, bool isRecursive);
        Task<ListResponse<StaffVM>> Get(ListGeneralModel page, Guid userId);
        Task<StaffVM> GetEdit(Guid id, Guid userId);
        Task<bool> Save(StaffVM request, Guid userId);
    }
}
