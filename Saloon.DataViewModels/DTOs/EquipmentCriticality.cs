using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class EquipmentCriticality
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Equipment> Equipment { get; } = new List<Equipment>();
}
