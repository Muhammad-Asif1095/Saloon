//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Saloon.Data.Context;
//using Saloon.DataViewModels.Enum.Admin.v1;
//using Saloon.DataViewModels.Response.Admin.v1;
//using Saloon.Services.Interface.v1.App;

//namespace Saloon.Services.Implementation.v1.App
//{
//    public class ReportService : IReportService
//  {
//    public decimal GetTotalEquipmentAvrageResponseTime(Guid userId)
//    {
//      try
//      {
//        DateTime Startdate = DateTime.Now.AddDays(-30);
//        DateTime endDate = DateTime.Now;

//        using (var db = new SaloonDbContext())
//        {
//          var count = db.EquipmentInAlarmStateLogs
//              .Count(x => !x.Equipment.IsDeleted && !x.InAlarmState && x.CreatedOn >= Startdate && x.CreatedOn <= endDate && x.CreatedBy.Equals(userId));
//          if (count > 0)
//          {
//            var sum = db.EquipmentInAlarmStateLogs
//            .Where(x => !x.Equipment.IsDeleted && !x.InAlarmState && x.CreatedOn >= Startdate && x.CreatedOn <= endDate && x.CreatedBy.Equals(userId))
//            .Sum(x => x.Mttr ?? 0);

//            return count > 0 ? (sum / count) : 0;
//          }

//          return 0;
//        }
//      }
//      catch (Exception ex)
//      {
//        throw ex;
//      }
//    }

//    public int GetTotalEquipmentBreakdownSavedCount(Guid userId)
//    {
//      try
//      {
//        DateTime Startdate = DateTime.Now.AddDays(-30);
//        DateTime endDate = DateTime.Now;

//        using (var db = new SaloonDbContext())
//        {
//          return db.EquipmentInAlarmStateLogs.Count(x => !x.Equipment.IsDeleted && !x.InAlarmState && x.CreatedOn >= Startdate && x.CreatedOn <= endDate && x.CreatedBy.Equals(userId));
//        }
//      }
//      catch (Exception ex)
//      {
//        throw ex;
//      }
//    }

//    public decimal GetTotalEquipmentCompliance(Guid userId)
//    {
//      try
//      {
//        DateTime Startdate = DateTime.Now.AddDays(-30);
//        DateTime endDate = DateTime.Now;

//        using (var db = new SaloonDbContext())
//        {
//          var specif = db.RouteScheduleEquipments.Count(x => !x.RouteSchedule.Route.IsDeleted && x.RouteSchedule.RouteScheduleStatusId.ToString().ToLower().Equals(ERouteScheduleStatus.Missed.ToString().ToLower()) && x.RouteSchedule.CreatedOn >= Startdate && x.RouteSchedule.CreatedOn <= endDate && x.RouteSchedule.Route.AssignedTo.Equals(userId));
//          var total = db.RouteScheduleEquipments.Count(x => !x.RouteSchedule.Route.IsDeleted && x.RouteSchedule.CreatedOn >= Startdate && x.RouteSchedule.CreatedOn <= endDate && x.RouteSchedule.Route.AssignedTo.Equals(userId));
//          return total > 0 ? 100 - ((specif * 100) / total) : 0;
//        }
//      }
//      catch (Exception ex)
//      {
//        throw ex;
//      }
//    }

//    public decimal GetTotalNumberOfAnomallies(Guid userId)
//    {
//      try
//      {
//        DateTime Startdate = DateTime.Now.AddDays(-30);
//        DateTime endDate = DateTime.Now;

//        using (var db = new SaloonDbContext())
//        {
//          return db.RouteScheduleEquipmentIpData.Count(x => x.IsAnamoly && x.RouteScheduleEquipments.RouteSchedule.AssignedTo.Equals(userId));
//        }
//      }
//      catch (Exception ex)
//      {
//        throw ex;
//      }
//    }

//    public async Task<List<GetTotalRouteChartResponse>> AlarmTrendChart(Guid userId)
//    {
//      try
//      {
//        DateTime startDate = DateTime.Now.AddDays(-30);
//        DateTime endDate = DateTime.Now;

//        using (var db = new SaloonDbContext())
//        {
//          string query = @"EXEC [dbo].[MobileAlarmTrendChart] @UserId = '" + userId + "', @PresentStartDate = '" + startDate + "', @PresentEndDate = '" + endDate + "'";

//          return await db.Set<GetTotalRouteChartResponse>().FromSqlRaw(query)?.ToListAsync();
//        }
//      }
//      catch (Exception ex)
//      {
//        throw ex;
//      }
//    }

//    public async Task<GraphModelMobile<List<GraphModelMobile<DateTime, int>>, List<GraphModelMobile<DateTime, decimal>>>> WeeklyWorkOrder(Guid userId)
//    {
//      try
//      {
//        GraphModelMobile<List<GraphModelMobile<DateTime, int>>, List<GraphModelMobile<DateTime, decimal>>> response = new GraphModelMobile<List<GraphModelMobile<DateTime, int>>, List<GraphModelMobile<DateTime, decimal>>>();
//        DateTime startDate = DateTime.Now.AddDays(-28);
//        DateTime endDate = DateTime.Now;

//        int max = 0;

//        using (var db = new SaloonDbContext())
//        {
//          string queryAll = @"EXEC [dbo].[WeeklyWorkOrderByUser] @UserId = '" + userId + "', @PresentStartDate = '" + startDate + "', @PresentEndDate = '" + endDate + "'";

//          response.StartDate = await db.Set<GraphModelMobile<DateTime, int>>().FromSqlRaw(queryAll)?.ToListAsync();

//          max = response.StartDate.Max(x => x.Total);

//          string queryNotMissed = @"EXEC [dbo].[WeeklyNotMissedWorkOrderByUser] @UserId = '" + userId + "', @PresentStartDate = '" + startDate + "', @PresentEndDate = '" + endDate + "'";

//          var res = await db.Set<GraphModelMobile<DateTime, int>>().FromSqlRaw(queryNotMissed)?.ToListAsync();

//          response.Total = new List<GraphModelMobile<DateTime, decimal>>();

//          foreach (var item in res.OrderBy(x => x.StartDate).ToList())
//          {
//            response.Total.Add(new GraphModelMobile<DateTime, decimal>
//            {
//              StartDate = item.StartDate,
//              Total = max > 0 ? ((item.Total * 100) / max) : 0
//            });
//          }
//        }

//        return response;
//      }
//      catch (Exception ex)
//      {
//        throw ex;
//      }
//    }

//    public async Task<double> AVGInspectionPerMonthByUser(Guid userId)
//    {
//      try
//      {
//        DateTime startDate = DateTime.Now.AddMonths(-12);
//        DateTime endDate = DateTime.Now;

//        using (var db = new SaloonDbContext())
//        {
//          string queryNotMissed = @"EXEC [dbo].[AVGInspectionPerMonthByUser] @UserId = '" + userId + "', @PresentStartDate = '" + startDate + "', @PresentEndDate = '" + endDate + "'";

//          var list = await db.Set<GraphModelMobile<DateTime, int>>().FromSqlRaw(queryNotMissed)?.ToListAsync();

//          return list.Average(x => x.Total);
//        }
//      }
//      catch (Exception ex)
//      {
//        throw ex;
//      }
//    }

//    public async Task<List<GraphModelMobile<DateTime, int>>> InspectionPerDayByUser(Guid userId)
//    {
//      try
//      {
//        DateTime startDate = DateTime.Now.AddDays(-30);
//        DateTime endDate = DateTime.Now;

//        using (var db = new SaloonDbContext())
//        {
//          string queryNotMissed = @"EXEC [dbo].[InspectionPerDayByUser] @UserId = '" + userId + "', @PresentStartDate = '" + startDate + "', @PresentEndDate = '" + endDate + "'";

//          return await db.Set<GraphModelMobile<DateTime, int>>().FromSqlRaw(queryNotMissed)?.ToListAsync();
//        }
//      }
//      catch (Exception ex)
//      {
//        throw ex;
//      }
//    }
//        public async Task<int> GetEquipmentInAlarmCount(Guid userId)
//        {
//            try
//            {
//                using (var db = new SaloonDbContext())
//                {
//                    DateTime Startdate = DateTime.Now.Date.AddDays(-30);
//                    DateTime endDate = DateTime.Now.Date;
//                    return await db.RouteScheduleEquipments.Where(x => x.RouteSchedule.AssignedTo.Equals(userId) && x.RouteSchedule.StartsFrom.Date >= Startdate &&
//                                  x.RouteSchedule.StartsFrom.Date <= endDate && x.Equipment.InAlarmingState && !x.Equipment.IsDeleted).GroupBy(x => x.EquipmentId).Select(group => group.Key).CountAsync();
//                }
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//    }
//}
