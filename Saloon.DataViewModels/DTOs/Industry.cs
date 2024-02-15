using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class Industry
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Templates> Templates { get; } = new List<Templates>();
}
