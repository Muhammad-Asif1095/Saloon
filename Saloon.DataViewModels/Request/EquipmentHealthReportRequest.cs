using System;

namespace Saloon.DataViewModels.Report
{
    public class EquipmentHealthReportRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid EquipmentId { get; set; }

    }
}
