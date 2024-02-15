using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Saloon.DataViewModels.DTOs;
using Saloon.DataViewModels.Request.Admin.v1;
using Saloon.DataViewModels.Response.Admin.v1;
using ListGeneralModel = Saloon.DataViewModels.Request.Admin.v1.ListGeneralModel;

namespace Saloon.Services.Interface.v1.Admin
{
    public interface ICustomerSubscriptionService
    {
        Task<ListResponse<CustomerSubscriptionVM>> Get(ListGeneralModel page, Guid userId);
        Task<List<CustomersSubscriptions>> GetUserSubscriptions(Guid userId);
        Task<bool> Save(CustomerSubscriptionRequestVM request, Guid userId);
        Task<CustomerSubscriptionVM> GetEdit(Guid id, Guid userId);
        Task<bool> ControllActivation(Guid id, bool isActive, Guid userId);
        Task<bool> isExpiredByUser(Guid userId);
    }
}
