using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class MediaType
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<MediaStore> MediaStore { get; } = new List<MediaStore>();

    public virtual ICollection<MediaTypesFormats> MediaTypesFormats { get; } = new List<MediaTypesFormats>();
}
