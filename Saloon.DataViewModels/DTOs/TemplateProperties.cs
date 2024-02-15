using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class TemplateProperties
{
    public Guid Id { get; set; }

    public Guid TemplateTypeId { get; set; }

    public Guid PropertiesColumnId { get; set; }

    public virtual PropertiesColumn PropertiesColumn { get; set; }

    public virtual TemplateType TemplateType { get; set; }
}
