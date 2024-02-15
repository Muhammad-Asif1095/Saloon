using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class AdminUserRoles
{
    public Guid Id { get; set; }

    public Guid AdminUserId { get; set; }

    public Guid RoleId { get; set; }

    public bool IsEnabled { get; set; }

    public DateTime CreatedOnDate { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? UpdatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public string? DeletedBy { get; set; }

    public virtual AspNetUsers AdminUser { get; set; } = null!;

    public virtual Roles Role { get; set; } = null!;
}
