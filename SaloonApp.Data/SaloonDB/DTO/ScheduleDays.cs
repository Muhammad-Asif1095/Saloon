using System;
using System.Collections.Generic;

namespace SaloonApp.Data.SaloonDB.DTO
{
    public partial class ScheduleDays
    {
        public ScheduleDays()
        {
            StaffOccupiedTime = new HashSet<StaffOccupiedTime>();
            StaffSchedule = new HashSet<StaffSchedule>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<StaffOccupiedTime> StaffOccupiedTime { get; set; }
        public virtual ICollection<StaffSchedule> StaffSchedule { get; set; }
    }
}
