using System;

namespace Saloon.DataViewModels.DTOs;

public partial class RouteShifts
{
    public Guid Id { get; set; }

    public Guid RouteId { get; set; }

    public Guid ShiftsId { get; set; }

    public virtual Route Route { get; set; }

    public virtual Shifts Shifts { get; set; }
}
