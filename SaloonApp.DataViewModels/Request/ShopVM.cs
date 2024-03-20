namespace SaloonApp.DataViewModels.Request
{
    public class ShopVM
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; } = null!;

        public Guid ShopGenderCategoryId { get; set; }
        public string ShopGender { get; set; }

        public Guid ShopCategoryId { get; set; }
        public string ShopCategory { get; set; }

        public Guid CreatedBy { get; set; }
        public string CreatedByName { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
