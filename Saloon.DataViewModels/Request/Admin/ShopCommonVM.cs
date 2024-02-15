namespace Saloon.DataViewModels.Request.Admin
{
    public class ShopCommonVM
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public Guid CreatedBy { get; set; }
        public string CreatedByName { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
