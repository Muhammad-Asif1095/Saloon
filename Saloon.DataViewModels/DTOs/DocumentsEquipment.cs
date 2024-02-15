using System;

namespace Saloon.DataViewModels.DTOs;

public partial class DocumentsEquipment
{
    public Guid Id { get; set; }

    public Guid DocumentsId { get; set; }

    public Guid EquipmentId { get; set; }

    public virtual Documents Documents { get; set; }

    public virtual Equipment Equipment { get; set; }
}
