using Saloon.DataViewModels.Response.Admin.v1;

namespace Saloon.DataViewModels.Enum.Admin.v1
{
    public class EnumDocumentTypes
    {
        public const string MSDS = "44D9377D-4171-4EFA-9A9B-041F39717516";
        public const string Flowcharts = "CB01F1D8-AE2F-4DDB-9D41-9181587B9DD8";
        public const string Tutorials = "56DDE4AE-11AF-4B78-A92C-31AB33B32DF9";
        public const string SOPS = "5933596B-0A05-42B4-85EA-71658CE34525";

        public static List<IdNameVM> StatusWithNames = new List<IdNameVM>() {
            new IdNameVM(){ ID = new Guid("44D9377D-4171-4EFA-9A9B-041F39717516"), Name = "MSDS" },
            new IdNameVM(){ ID = new Guid("CB01F1D8-AE2F-4DDB-9D41-9181587B9DD8"), Name = "Flowcharts" },
            new IdNameVM(){ ID = new Guid("56DDE4AE-11AF-4B78-A92C-31AB33B32DF9"), Name = "Tutorials" },
            new IdNameVM(){ ID = new Guid("5933596B-0A05-42B4-85EA-71658CE34525"), Name = "SOPS" },
        };

        public static string GetName(Guid ID) => StatusWithNames.FirstOrDefault(x => x.ID.ToString().ToLower().Equals(ID.ToString().ToLower())).Name ?? "";
        public static string GetName(string ID) => StatusWithNames.FirstOrDefault(x => x.ID.ToString().ToLower().Equals(ID)).Name ?? "";
    }
}
