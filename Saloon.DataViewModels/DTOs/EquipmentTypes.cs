using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class EquipmentTypes
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string ImageUrl { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual AspNetUsers CreatedByNavigation { get; set; }

    public virtual AspNetUsers DeletedByNavigation { get; set; }

    public virtual ICollection<Documents> Documents { get; } = new List<Documents>();

    public virtual ICollection<Equipment> Equipment { get; } = new List<Equipment>();

    public virtual AspNetUsers LastModifiedByNavigation { get; set; }
}
