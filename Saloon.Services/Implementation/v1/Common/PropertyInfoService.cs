using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Saloon.DataViewModels.Common;
using Saloon.DataViewModels.Enum.Admin.v1;
using Saloon.DataViewModels.Request.Admin.v1;
using Saloon.Services.Interface.v1.Common;

namespace Saloon.Services.Implementation.v1.Common
{
    public class PropertyInfoService : IPropertyInfoService
    {

        public  List<PropertyInfoVM> GetProperties(Guid TemplateTypeId)
        {

            switch (TemplateTypeId.ToString().ToUpper())
            {
                //case EnumTemplateType.Branch:
                //    return GetViewModelProperties<BranchRequestVM>();
                //case EnumTemplateType.Section:
                //    return GetViewModelProperties<SectionRequestVM>();
                //case EnumTemplateType.SubSection:
                //    return GetViewModelProperties<SubSectionRequestVM>();
                //case EnumTemplateType.Asset:
                //    return GetViewModelProperties<AssetRequestVM>();
                //case EnumTemplateType.Equipment:
                //    return GetViewModelProperties<EquipmentRequestVM>();
                //case EnumTemplateType.IP:
                //    return GetViewModelProperties<IPRequestVM>();
                //case EnumTemplateType.IpOptions:
                //    return GetViewModelProperties<IpOptionsRequestVM>();
                //case EnumTemplateType.IpAnomalyRanges:
                //    return GetViewModelProperties<IpAnomalyRangesRequestVM>();
                //default:
                case "ABC":
                    return new List<PropertyInfoVM>();
                default:
                    return new List<PropertyInfoVM>();
            }
        }
        public static List<PropertyInfoVM> GetViewModelProperties<T>() where T : class
        {
            var properties = typeof(T)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
              .Select(p => new PropertyInfoVM
              {
                  Name = p.Name,
                  Type = GetPropertyType(p.Name)
              })
              .ToList();

            return properties;
        }
        private static string GetPropertyType(string propertyName)
        {
            if (propertyName == "CustomerId" || propertyName == "BranchId" || propertyName == "SectionId" || propertyName == "SubSectionId" || propertyName == "AssetId" || propertyName == "EquipmentId")
                return "<PARENTID>";
            if (propertyName == "Name" || propertyName == "Code" || propertyName == "ExternalCode") return "<STRING>";
            if (propertyName == "Id") return "<AUTOGUID>";
            if (propertyName == "IpCriticalityId" || propertyName == "AssetsStatusId" || propertyName == "EquipmentCriticalityId" || propertyName == "IpTypeId" || propertyName == "EquipmentTypeId" ||
                propertyName == "IpToolId" || propertyName == "IpFacultyId" || propertyName == "IpEngineeringUnitId" || propertyName == "IpDataTypeId" || propertyName == "FrequencyId")
                return "<Guid>";
            if (propertyName == "ColorHex") return "<ColorPicker>";
            return "Boolean";
        }
    }
}