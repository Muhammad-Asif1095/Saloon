using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class Documents
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid DocumentTypesId { get; set; }

    public Guid? EquipmentTypesId { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public bool IsProductOwner { get; set; }

    public Guid? ImageMediaId { get; set; }

    public virtual AspNetUsers CreatedByNavigation { get; set; }

    public virtual AspNetUsers DeletedByNavigation { get; set; }

    public virtual DocumentTypes DocumentTypes { get; set; }

    public virtual ICollection<DocumentsEquipment> DocumentsEquipment { get; } = new List<DocumentsEquipment>();

    public virtual EquipmentTypes EquipmentTypes { get; set; }

    public virtual Media ImageMedia { get; set; }

    public virtual AspNetUsers LastModifiedByNavigation { get; set; }
}
