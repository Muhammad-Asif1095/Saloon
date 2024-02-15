using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class TemplateRecipeSteps
{
    public Guid Id { get; set; }

    public Guid TemplateRecipeId { get; set; }

    public Guid TemplateId { get; set; }

    public Guid? ParentId { get; set; }

    public virtual Templates Template { get; set; }

    public virtual TemplateRecipe TemplateRecipe { get; set; }
}
