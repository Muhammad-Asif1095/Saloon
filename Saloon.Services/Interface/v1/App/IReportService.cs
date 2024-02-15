using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Saloon.DataViewModels.Response.Admin.v1;

namespace Saloon.Services.Interface.v1.App
{
    public interface IReportService
    {
        decimal GetTotalEquipmentAvrageResponseTime(Guid userId);
        int GetTotalEquipmentBreakdownSavedCount(Guid userId);
        decimal GetTotalEquipmentCompliance(Guid userId);
        decimal GetTotalNumberOfAnomallies(Guid userId);
        //Task<List<GetTotalRouteChartResponse>> AlarmTrendChart(Guid userId);
        //Task<GraphModelMobile<List<GraphModelMobile<DateTime, int>>, List<GraphModelMobile<DateTime, decimal>>>> WeeklyWorkOrder(Guid userId);
        //Task<double> AVGInspectionPerMonthByUser(Guid userId);
        //Task<List<GraphModelMobile<DateTime, int>>> InspectionPerDayByUser(Guid userId);
        Task<int> GetEquipmentInAlarmCount(Guid userId);
    }
}
