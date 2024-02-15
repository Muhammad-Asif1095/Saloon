using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.Common
{
    public class HeirarchyObject
    {
        public List<Guid> Branchs { get; set; } = new List<Guid>();
        public List<Guid> Sections { get; set; } = new List<Guid>();
        public List<Guid> SubSections { get; set; } = new List<Guid>();
        public List<Guid> Assets { get; set; } = new List<Guid>();
        public List<Guid> Equipments { get; set; } = new List<Guid>();
    }
}
