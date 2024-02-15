using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class DocumentTypes
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Documents> Documents { get; } = new List<Documents>();
}
