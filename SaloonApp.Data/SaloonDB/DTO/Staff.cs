﻿using System;
using System.Collections.Generic;

namespace SaloonApp.Data.SaloonDB.DTO
{
    public partial class Staff
    {
        public Staff()
        {
            StaffOccupiedTime = new HashSet<StaffOccupiedTime>();
            StaffSchedule = new HashSet<StaffSchedule>();
            StaffServices = new HashSet<StaffServices>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public string? MobileNo { get; set; }
        public string? Image { get; set; }
        public DateTime JobStartDate { get; set; }
        public string? Speciality { get; set; }
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
        public virtual ICollection<StaffOccupiedTime> StaffOccupiedTime { get; set; }
        public virtual ICollection<StaffSchedule> StaffSchedule { get; set; }
        public virtual ICollection<StaffServices> StaffServices { get; set; }
    }
}
