using System;

namespace Saloon.DataViewModels.Request
{
    public class ScheduledRouteAssigneeRequest
  {
    public Guid UserID { get; set; }
    public Guid ScheduledRouteID { get; set; }
  }
}
