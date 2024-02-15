using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class TemplateIndustry
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<TemplateRecipe> TemplateRecipe { get; } = new List<TemplateRecipe>();
}
