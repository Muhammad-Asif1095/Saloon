using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class IpEngineeringUnit
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual AspNetUsers CreatedByNavigation { get; set; }

    public virtual AspNetUsers DeletedByNavigation { get; set; }

    public virtual ICollection<Ip> Ip { get; } = new List<Ip>();

    public virtual AspNetUsers LastModifiedByNavigation { get; set; }
}
