namespace Saloon.DataViewModels.Response.Admin.v1
{
    public class CustomerSubscriptionVM
    {
        public Guid Id { get; set; }
        public Guid PackageId { get; set; }
        public string PackageName { get; set; }
        public DateTime SignedOn { get; set; }
        public DateTime ValidThrough { get; set; }
        public Guid? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public bool IsActive { get; set; }
        public Guid CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
