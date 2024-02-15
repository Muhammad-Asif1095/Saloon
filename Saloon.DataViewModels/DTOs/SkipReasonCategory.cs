using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class SkipReasonCategory
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<SkipReasons> SkipReasons { get; } = new List<SkipReasons>();
}
