using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class UserType
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AspNetUsers> AspNetUsers { get; } = new List<AspNetUsers>();
}
