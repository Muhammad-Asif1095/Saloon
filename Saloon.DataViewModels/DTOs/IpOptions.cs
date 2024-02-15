using System;

namespace Saloon.DataViewModels.DTOs;

public partial class IpOptions
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid IpId { get; set; }

    public bool IsExpected { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual AspNetUsers CreatedByNavigation { get; set; }

    public virtual AspNetUsers DeletedByNavigation { get; set; }

    public virtual Ip Ip { get; set; }

    public virtual AspNetUsers LastModifiedByNavigation { get; set; }
}
