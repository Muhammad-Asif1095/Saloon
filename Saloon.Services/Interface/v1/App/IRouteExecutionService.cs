using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Saloon.DataViewModels.Common;

namespace Saloon.Services.Interface.v1.App
{
    public interface IRouteExecutionService
    {
        Task<List<RoutesScheduledVM>> GetExecutionRoutes(Guid UserId, string rootPath);
        Task<bool> SaveRouteData(ExecutionDataVM executionData, Guid userId, string rootPath);
        bool SetRouteInProgress(Guid scheduledRouteID, string rootPath);
        bool CancelRoute(Guid scheduledRouteID, string rootPath);
    }
}
