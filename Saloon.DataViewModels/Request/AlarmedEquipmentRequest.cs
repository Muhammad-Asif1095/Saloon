using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Saloon.DataViewModels.Common;

namespace Saloon.DataViewModels.Request
{
    public class AlarmedEquipmentRequest
    {
        [JsonProperty(PropertyName = "page")]
        public int Page { get; set; }

        [JsonProperty(PropertyName = "pageSize")]
        public int PageSize { get; set; }

        [JsonProperty(PropertyName = "totalRecords")]
        public int TotalRecords { get; set; }

        [JsonProperty(PropertyName = "search")]
        public string Search { get; set; }

        [JsonProperty(PropertyName = "sortBy")]
        public List<RequestResponseSort> SortBy { get; set; } = new List<RequestResponseSort>();

        [JsonProperty(PropertyName = "id")]
        public Guid? Id { get; set; }

        [JsonProperty(PropertyName = "equipmentId")]
        public Guid? EquipmentId { get; set; }

        [JsonProperty(PropertyName = "assetId")]
        public Guid? AssetId { get; set; }

        [JsonProperty(PropertyName = "subSectionId")]
        public Guid? SubSectionId { get; set; }

        [JsonProperty(PropertyName = "sectionId")]
        public Guid? SectionId { get; set; }

        [JsonProperty(PropertyName = "equipmentTypeId")]
        public Guid? EquipmentTypeId { get; set; }

        [JsonProperty(PropertyName = "equipmentCriticalityId")]
        public Guid? EquipmentCriticalityId { get; set; }

        [JsonProperty(PropertyName = "ipName")]
        public string IpName { get; set; }

        [JsonProperty(PropertyName = "ipCode")]
        public string IpCode { get; set; }

        [JsonProperty(PropertyName = "ipDataTypeId")]
        public object IpDataTypeId { get; set; }

        [JsonProperty(PropertyName = "ipCriticalityId")]
        public Guid? IpCriticalityId { get; set; }

        [JsonProperty(PropertyName = "ipFacultyId")]
        public Guid? IpFacultyId { get; set; }

        [JsonProperty(PropertyName = "ipTypeId")]
        public Guid? IpTypeId { get; set; }
        public Guid? BranchId { get; set; }
        //EquipmentId
        //  AssetId
    }

    public class AlarmDetailVM
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }
        [JsonProperty(PropertyName = "criticalityName")]
        public string CriticalityName { get; set; }
        [JsonProperty(PropertyName = "dataTypeName")]
        public string DataTypeName { get; set; }
        [JsonProperty(PropertyName = "typeName")]
        public string TypeName { get; set; }
        [JsonProperty(PropertyName = "facultyName")]
        public string FacultyName { get; set; }
        [JsonProperty(PropertyName = "routeName")]
        public string RouteName { get; set; }
        [JsonProperty(PropertyName = "scheduledOn")]
        public DateTime ScheduledOn { get; set; }
        [JsonProperty(PropertyName = "reportedBy")]
        public string ReportedBy { get; set; }
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
        [JsonProperty(PropertyName = "expectedValue")]
        public string ExpectedValue { get; set; }

        [JsonProperty(PropertyName = "createdOn")]
        public DateTime CreatedOn { get; set; }

    }

    public class GetAlarmedDetailRequest
    {
        [JsonProperty(PropertyName = "equipmentId")]
        public Guid EquipmentId { get; set; }
        [JsonProperty(PropertyName = "startDate")]
        public DateTime? StartDate { get; set; }

        [JsonProperty(PropertyName = "endDate")]
        public DateTime? EndDate { get; set; }
    }

    public class TimeSpanRequest
    {
        [JsonProperty(PropertyName = "startDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty(PropertyName = "endDate")]
        public DateTime EndDate { get; set; }
        [JsonProperty(PropertyName = "branchIDs")]
        public List<Guid> BranchIDs { get; set; }
    }

    public class AlarmedEquipmentResponseVM
    {

        [JsonProperty(PropertyName = "itemType")]
        public int ItemType { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "timeStamp")]
        public DateTime TimeStamp { get; set; }

        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "criticalityName")]
        public string CriticalityName { get; set; }

        [JsonProperty(PropertyName = "dataTypeName")]
        public string DataTypeName { get; set; }

        [JsonProperty(PropertyName = "typeName")]
        public string TypeName { get; set; }

        [JsonProperty(PropertyName = "facultyName")]
        public string FacultyName { get; set; }

        [JsonProperty(PropertyName = "routeName")]
        public string RouteName { get; set; }

        [JsonProperty(PropertyName = "scheduledOn")]
        public DateTime ScheduledOn { get; set; }

        [JsonProperty(PropertyName = "reportedBy")]
        public string ReportedBy { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "expectedValue")]
        public string ExpectedValue { get; set; }

        [JsonProperty(PropertyName = "logInAlarmState")]
        public bool? LogInAlarmState { get; set; }

        [JsonProperty(PropertyName = "workOrderStatus")]
        public string WorkOrderStatus { get; set; }

        [JsonProperty(PropertyName = "workOrderCreatedBy")]
        public string WorkOrderCreatedBy { get; set; }

        [JsonProperty(PropertyName = "workOrderAssignedTo")]
        public string WorkOrderAssignedTo { get; set; }
    }
}
