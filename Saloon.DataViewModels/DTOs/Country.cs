using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class Country
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ClientBank> ClientBank { get; } = new List<ClientBank>();

    public virtual ICollection<Province> Province { get; } = new List<Province>();
}
