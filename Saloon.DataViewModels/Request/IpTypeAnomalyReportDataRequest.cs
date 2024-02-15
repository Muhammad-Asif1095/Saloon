using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.Request
{
    public class IpTypeAnomalyReportDataRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid? IpTypeId { get; set; }
        public List<Guid> BranchIDs { get; set; }
    }
}
