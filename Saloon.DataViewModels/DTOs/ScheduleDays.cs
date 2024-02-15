using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class ScheduleDays
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<StaffOccupiedTime> StaffOccupiedTime { get; } = new List<StaffOccupiedTime>();

    public virtual ICollection<StaffSchedule> StaffSchedule { get; } = new List<StaffSchedule>();
}
