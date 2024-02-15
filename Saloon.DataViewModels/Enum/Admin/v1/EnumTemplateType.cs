using System.Collections.Generic;
using System;
using Saloon.DataViewModels.Response.Admin.v1;

namespace Saloon.DataViewModels.Enum.Admin.v1
{
    public class EnumTemplateType
    {
        public const string Branch = "938A3A72-72B6-40E7-B247-383F6C2B5823";
        public const string Section = "F0E3F28D-5268-4FE3-9B7E-488EA4DAB0B5";
        public const string SubSection = "77F6FFE8-5FC9-4BB0-9DEA-7138216A069B";
        public const string Asset = "B7FECE02-7D12-4CF8-A401-31940C0EC92D";
        public const string Equipment = "0C3462DD-170C-49BA-84E0-0C7072915454";
        public const string IP = "D58F70C8-A309-4C2A-AB11-48FAD89E902E";
        public const string IpOptions = "8789C592-97AC-4DFD-B5D8-CE930AFB96FE";
        public const string IpAnomalyRanges = "DADE4FA3-5364-462B-968B-47599D7DD438";

        public static List<IdNameVM> StatusWithNames = new List<IdNameVM>() {
            new IdNameVM(){ ID = new Guid(Branch), Name = "Branch" },
            new IdNameVM(){ ID = new Guid(Section), Name = "Section" },
            new IdNameVM(){ ID = new Guid(SubSection), Name = "SubSection" },
            new IdNameVM(){ ID = new Guid(Asset), Name = "Asset" },
            new IdNameVM(){ ID = new Guid(Equipment), Name = "Equipment" },
            new IdNameVM(){ ID = new Guid(IP), Name = "IP" },
            new IdNameVM(){ ID = new Guid(IpOptions), Name = "IpOptions" },
            new IdNameVM(){ ID = new Guid(IpAnomalyRanges), Name = "IpAnomalyRanges" }
        };
    }
}
