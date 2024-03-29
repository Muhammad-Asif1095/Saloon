﻿using System;
using System.Collections.Generic;

namespace SaloonApp.Data.SaloonDB.DTO
{
    public partial class AccessRightTypes
    {
        public AccessRightTypes()
        {
            AspNetUsers = new HashSet<AspNetUsers>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsEnabled { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string? DeletedBy { get; set; }

        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
    }
}
