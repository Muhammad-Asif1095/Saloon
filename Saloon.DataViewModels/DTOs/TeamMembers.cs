using System;

namespace Saloon.DataViewModels.DTOs;

public partial class TeamMembers
{
    public Guid Id { get; set; }

    public Guid TeamsId { get; set; }

    public Guid AspNetUsersId { get; set; }

    public virtual AspNetUsers AspNetUsers { get; set; }

    public virtual Teams Teams { get; set; }
}
