using System;
using System.Collections.Generic;

namespace SaloonApp.Data.SaloonDB.DTO
{
    public partial class MediaStore
    {
        public MediaStore()
        {
            AspNetUsersImageMediaStore = new HashSet<AspNetUsers>();
            AspNetUsersImageThumbnailMediaStore = new HashSet<AspNetUsers>();
            Customers = new HashSet<Customers>();
        }

        public Guid Id { get; set; }
        public Guid MediaTypeId { get; set; }
        public string MediaUri { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string? MediaName { get; set; }

        public virtual MediaType MediaType { get; set; } = null!;
        public virtual ICollection<AspNetUsers> AspNetUsersImageMediaStore { get; set; }
        public virtual ICollection<AspNetUsers> AspNetUsersImageThumbnailMediaStore { get; set; }
        public virtual ICollection<Customers> Customers { get; set; }
    }
}
