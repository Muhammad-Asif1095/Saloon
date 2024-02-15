using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class ShiftsType
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Shifts> Shifts { get; } = new List<Shifts>();
}
