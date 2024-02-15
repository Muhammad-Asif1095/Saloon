using System;
using System.Collections.Generic;
using System.Linq;
using Saloon.DataViewModels.Response.Admin.v1;

namespace Saloon.DataViewModels.Enum.Admin.v1
{
    public class EnumMediaTypes
    {
        public const string Document = "BFE46F9C-5DBC-4E69-BF3A-09F8B5DD4154";
        public const string Video = "E3D2DD2E-6872-4C64-AF16-4F13015D09CA";
        public const string Image = "DB91C671-EA63-411B-9586-FB42B61A4078";
        public const string Audio = "5E7FB846-867D-40E3-81F4-FE2F160001CB";

        public static List<IdNameVM> StatusWithNames = new List<IdNameVM>() {
            new IdNameVM(){ ID = new Guid("BFE46F9C-5DBC-4E69-BF3A-09F8B5DD4154"), Name = "Document" },
            new IdNameVM(){ ID = new Guid("E3D2DD2E-6872-4C64-AF16-4F13015D09CA"), Name = "Video" },
            new IdNameVM(){ ID = new Guid("DB91C671-EA63-411B-9586-FB42B61A4078"), Name = "Image" },
            new IdNameVM(){ ID = new Guid("5E7FB846-867D-40E3-81F4-FE2F160001CB"), Name = "Audio" },
        };

        public static string GetName(Guid ID) => StatusWithNames.FirstOrDefault(x => x.ID.ToString().ToLower().Equals(ID.ToString().ToLower())).Name ?? "";
        public static string GetName(string ID) => StatusWithNames.FirstOrDefault(x => x.ID.ToString().ToLower().Equals(ID)).Name ?? "";
    }
}    