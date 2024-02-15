namespace Saloon.DataViewModels.Response.Admin.v1
{
    public class RolesRightsManagement
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<RolesRightsManagementRight> Rights { get; set; }
    }

    public class RolesRightsManagementRight
    {
        public Guid Id { get; set; }
        public Guid RightId { get; set; }
        public string Name { get; set; }
        public bool Granted { get; set; }
        public string CreatedBy { get; set; }

    }
    public class RolesRightsResponseVM : RolesRightsManagement
    {
        public string CreatedByName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
