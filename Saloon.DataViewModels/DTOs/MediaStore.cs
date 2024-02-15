using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class MediaStore
{
    public Guid Id { get; set; }

    public Guid MediaTypeId { get; set; }

    public string MediaUri { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public string? MediaName { get; set; }

    public virtual ICollection<AspNetUsers> AspNetUsersImageMediaStore { get; } = new List<AspNetUsers>();

    public virtual ICollection<AspNetUsers> AspNetUsersImageThumbnailMediaStore { get; } = new List<AspNetUsers>();

    public virtual ICollection<Customers> Customers { get; } = new List<Customers>();

    public virtual MediaType MediaType { get; set; } = null!;
}
