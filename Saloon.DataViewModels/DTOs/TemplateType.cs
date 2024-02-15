using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class TemplateType
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<TemplateProperties> TemplateProperties { get; } = new List<TemplateProperties>();

    public virtual ICollection<Templates> Templates { get; } = new List<Templates>();
}
