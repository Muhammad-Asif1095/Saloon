using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class WorkOrders
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid EquipmentId { get; set; }

    public string Description { get; set; }

    public string StepsToTake { get; set; }

    public Guid AssignedTo { get; set; }

    public DateTime Eta { get; set; }

    public Guid WorderOrderStatusId { get; set; }

    public Guid WorkOrderSourceId { get; set; }

    public DateTime? StatusChangedOn { get; set; }

    public string Remarks { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual AspNetUsers AssignedToNavigation { get; set; }

    public virtual AspNetUsers CreatedByNavigation { get; set; }

    public virtual AspNetUsers DeletedByNavigation { get; set; }

    public virtual Equipment Equipment { get; set; }

    public virtual ICollection<EquipmentInAlarmStateLogs> EquipmentInAlarmStateLogs { get; } = new List<EquipmentInAlarmStateLogs>();


    public virtual AspNetUsers LastModifiedByNavigation { get; set; }

    public virtual WorkOrdersStatus WorderOrderStatus { get; set; }

    public virtual WorkOrderSource WorkOrderSource { get; set; }

    public virtual ICollection<WorkOrderStatusLog> WorkOrderStatusLog { get; } = new List<WorkOrderStatusLog>();

    public virtual ICollection<WorkOrdersMedia> WorkOrdersMedia { get; } = new List<WorkOrdersMedia>();
}
