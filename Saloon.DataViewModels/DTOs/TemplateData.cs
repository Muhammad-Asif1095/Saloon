using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class TemplateData
{
    public Guid Id { get; set; }

    public Guid TemplateId { get; set; }

    public string ColumnName { get; set; }

    public string ColumnValue { get; set; }

    public virtual Templates Template { get; set; }
}
