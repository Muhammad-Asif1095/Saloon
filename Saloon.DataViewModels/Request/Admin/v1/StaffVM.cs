namespace Saloon.DataViewModels.Request.Admin.v1
{
    public class StaffVM
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Email { get; set; }

        public string? MobileNo { get; set; }

        public string? Image { get; set; }

        public DateTime JobStartDate { get; set; }

        public string? Speciality { get; set; }

        public Guid CreatedBy { get; set; }
        public string CreatedByName { get; set; }

        public DateTime CreatedOn { get; set; }
        public List<StaffServicesVM> Services { get; set; }
    }
    public class StaffServicesVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
