using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.Common
{
    public partial class RoutesScheduledVM
    {
        [JsonProperty(PropertyName = "id")]
        public Guid ID { get; set; }

        [JsonProperty(PropertyName = "routeScheduleStatusId")]
        public Guid RouteScheduleStatusID { get; set; }

        [JsonProperty(PropertyName = "routeScheduleStatusName")]
        public string RouteScheduleStatusName { get; set; }

        [JsonProperty(PropertyName = "createdOn")]
        public DateTime CreatedOn { get; set; }

        [JsonProperty(PropertyName = "startsFrom")]
        public DateTime StartsFrom { get; set; }

        [JsonProperty(PropertyName = "EndsOn")]
        public DateTime EndsOn { get; set; }

        [JsonProperty(PropertyName = "routeId")]
        public Guid RouteID { get; set; }

        [JsonProperty(PropertyName = "routeName")]
        public string RouteName { get; set; }

        [JsonProperty(PropertyName = "frequency")]
        public string Frequency { get; set; }

        [JsonProperty(PropertyName = "equipments")]
        public IEnumerable<EquipmentsVM> Equipments { get; set; }
    }

    public partial class EquipmentsVM
    {

        [JsonProperty(PropertyName = "routeScheduleID")]
        public Guid RouteScheduleID { get; set; }

        [JsonProperty(PropertyName = "secheduledRouteEquipmentId")]
        public Guid SecheduledRouteEquipmentID { get; set; }

        [JsonProperty(PropertyName = "sequence")]
        public int Sequence { get; set; }

        [JsonProperty(PropertyName = "equipmentId")]
        public Guid EquipmentID { get; set; }

        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "equipmentType")]
        public string EquipmentType { get; set; }

        [JsonProperty(PropertyName = "asset")]
        public string Asset { get; set; }

        [JsonProperty(PropertyName = "subSection")]
        public string SubSection { get; set; }

        [JsonProperty(PropertyName = "section")]
        public string Section { get; set; }

        [JsonProperty(PropertyName = "branch")]
        public string Branch { get; set; }

        [JsonProperty(PropertyName = "externalcode")]
        public string ExternalCode { get; set; }
        [JsonProperty(PropertyName = "ips")]
        public IEnumerable<IpVM> IPs { get; set; }
    }

    public partial class IpVM
    {
        [JsonProperty(PropertyName = "secheduledRouteEquipmentID")]
        public Guid SecheduledRouteEquipmentID { get; set; }

        [JsonProperty(PropertyName = "IpId")]
        public Guid IpID { get; set; }

        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "sequence")]
        public int Sequence { get; set; }

        [JsonProperty(PropertyName = "ipDataTypeId")]
        public Guid IpDataTypeID { get; set; }

        [JsonProperty(PropertyName = "engineeringUnit")]
        public string EngineeringUnit { get; set; }

        [JsonProperty(PropertyName = "tool")]
        public string Tool { get; set; }

        [JsonProperty(PropertyName = "options")]
        public IEnumerable<OptionsVM> Options { get; set; }
    }
    public partial class OptionsVM
    {
        [JsonProperty(PropertyName = "id")]
        public Guid ID { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

    public partial class ExecutionDataVM
    {
        [JsonProperty(PropertyName = "scheduledRouteId")]
        public Guid ScheduledRouteID { get; set; }

        [JsonProperty(PropertyName = "isSkipped")]
        public bool IsSkipped { get; set; }

        [JsonProperty(PropertyName = "skipReasonsId")]
        public Guid SkipReasonsID { get; set; }

        [JsonProperty(PropertyName = "inspectionEndedAt")]
        public DateTime InspectionEndedAt { get; set; }

        [JsonProperty(PropertyName = "equipments")]
        public IEnumerable<SaveExecutionDataEquipmentVM> Equipments { get; set; }
    }

    public partial class SaveExecutionDataEquipmentVM
    {
        [JsonProperty(PropertyName = "secheduledRouteEquipmentID")]
        public Guid SecheduledRouteEquipmentID { get; set; }

        [JsonProperty(PropertyName = "isSkipped")]
        public bool IsSkipped { get; set; }

        [JsonProperty(PropertyName = "skipReasonsID")]
        public Guid SkipReasonsID { get; set; }

        [JsonProperty(PropertyName = "inspectionStartedAt")]
        public DateTime InspectionStartedAt { get; set; }

        [JsonProperty(PropertyName = "inspectionEndedAt")]
        public DateTime InspectionEndedAt { get; set; }

        [JsonProperty(PropertyName = "recordedAtLat")]
        public string RecordedAtLat { get; set; }

        [JsonProperty(PropertyName = "recordedAtLong")]
        public string RecordedAtLong { get; set; }

        [JsonProperty(PropertyName = "ips")]
        public IEnumerable<SaveExecutionDataEquipmentIpVM> Ips { get; set; }

        
    }

    public partial class SaveExecutionDataEquipmentIpVM
    {
        [JsonProperty(PropertyName = "IpId")]
        public Guid IpID { get; set; }

        [JsonProperty(PropertyName = "isSkipped")]
        public bool IsSkipped { get; set; }

        [JsonProperty(PropertyName = "skipReasonsID")]
        public Guid? SkipReasonsID { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "recordedAt")]
        public DateTime RecordedAt { get; set; }

        [JsonProperty(PropertyName = "images")]
        public List<FileUrlResponce> Images { get; set; }
    }

    public partial class CustomerInShift
    {
        public Guid CustomerID { get; set; }
        public bool InShift { get; set; }
    }
}
