using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class PropertiesColumn
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<TemplateProperties> TemplateProperties { get; } = new List<TemplateProperties>();
}
