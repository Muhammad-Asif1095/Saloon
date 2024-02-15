using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class RouteScheduleStatus
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<RouteSchedule> RouteSchedule { get; } = new List<RouteSchedule>();
}
