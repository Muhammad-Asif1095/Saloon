using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class Teams
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid AspNetUsersSupervisorId { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual AspNetUsers AspNetUsersSupervisor { get; set; }

    public virtual AspNetUsers CreatedByNavigation { get; set; }

    public virtual AspNetUsers DeletedByNavigation { get; set; }

    public virtual AspNetUsers ModifiedByNavigation { get; set; }

    public virtual ICollection<TeamMembers> TeamMembers { get; } = new List<TeamMembers>();
}
