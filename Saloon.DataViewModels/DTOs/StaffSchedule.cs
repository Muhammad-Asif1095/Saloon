﻿using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class StaffSchedule
{
    public Guid Id { get; set; }

    public Guid ScheduleDayId { get; set; }

    public Guid StaffId { get; set; }

    public DateTime StartsFrom { get; set; }

    public DateTime EndsOn { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual AspNetUsers CreatedByNavigation { get; set; } = null!;

    public virtual AspNetUsers? DeletedByNavigation { get; set; }

    public virtual AspNetUsers? ModifiedByNavigation { get; set; }

    public virtual ScheduleDays ScheduleDay { get; set; } = null!;

    public virtual Staff Staff { get; set; } = null!;
}
