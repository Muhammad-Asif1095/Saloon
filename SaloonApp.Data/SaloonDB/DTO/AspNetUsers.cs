using System;
using System.Collections.Generic;

namespace SaloonApp.Data.SaloonDB.DTO
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            AdminUserRoles = new HashSet<AdminUserRoles>();
            ClientBankAspNetUser = new HashSet<ClientBank>();
            ClientBankCreatedByNavigation = new HashSet<ClientBank>();
            ClientBankDeletedByNavigation = new HashSet<ClientBank>();
            ClientBankModifiedByNavigation = new HashSet<ClientBank>();
            ClientServicesCreatedByNavigation = new HashSet<ClientServices>();
            ClientServicesDeletedByNavigation = new HashSet<ClientServices>();
            ClientServicesModifiedByNavigation = new HashSet<ClientServices>();
            CustomersCreatedByNavigation = new HashSet<Customers>();
            CustomersDeletedByNavigation = new HashSet<Customers>();
            CustomersLastModifiedByNavigation = new HashSet<Customers>();
            CustomersSubscriptionsCreatedByNavigation = new HashSet<CustomersSubscriptions>();
            CustomersSubscriptionsDeletedByNavigation = new HashSet<CustomersSubscriptions>();
            CustomersSubscriptionsLastModifiedByNavigation = new HashSet<CustomersSubscriptions>();
            DiscountedProductsCreatedByNavigation = new HashSet<DiscountedProducts>();
            DiscountedProductsDeletedByNavigation = new HashSet<DiscountedProducts>();
            DiscountedProductsModifiedByNavigation = new HashSet<DiscountedProducts>();
            DiscountedServicesCreatedByNavigation = new HashSet<DiscountedServices>();
            DiscountedServicesDeletedByNavigation = new HashSet<DiscountedServices>();
            DiscountedServicesModifiedByNavigation = new HashSet<DiscountedServices>();
            NotificationsSubscription = new HashSet<NotificationsSubscription>();
            ProductCreatedByNavigation = new HashSet<Product>();
            ProductDeletedByNavigation = new HashSet<Product>();
            ProductModifiedByNavigation = new HashSet<Product>();
            Roles = new HashSet<Roles>();
            ShopCategoryCreatedByNavigation = new HashSet<ShopCategory>();
            ShopCategoryDeletedByNavigation = new HashSet<ShopCategory>();
            ShopCategoryModifiedByNavigation = new HashSet<ShopCategory>();
            ShopCreatedByNavigation = new HashSet<Shop>();
            ShopDeletedByNavigation = new HashSet<Shop>();
            ShopGenderCategoryCreatedByNavigation = new HashSet<ShopGenderCategory>();
            ShopGenderCategoryDeletedByNavigation = new HashSet<ShopGenderCategory>();
            ShopGenderCategoryModifiedByNavigation = new HashSet<ShopGenderCategory>();
            ShopModifiedByNavigation = new HashSet<Shop>();
            StaffCreatedByNavigation = new HashSet<Staff>();
            StaffDeletedByNavigation = new HashSet<Staff>();
            StaffModifiedByNavigation = new HashSet<Staff>();
            StaffOccupiedTimeCreatedByNavigation = new HashSet<StaffOccupiedTime>();
            StaffOccupiedTimeDeletedByNavigation = new HashSet<StaffOccupiedTime>();
            StaffOccupiedTimeModifiedByNavigation = new HashSet<StaffOccupiedTime>();
            StaffScheduleCreatedByNavigation = new HashSet<StaffSchedule>();
            StaffScheduleDeletedByNavigation = new HashSet<StaffSchedule>();
            StaffScheduleModifiedByNavigation = new HashSet<StaffSchedule>();
            StaffServicesCreatedByNavigation = new HashSet<StaffServices>();
            StaffServicesDeletedByNavigation = new HashSet<StaffServices>();
            StaffServicesModifiedByNavigation = new HashSet<StaffServices>();
            UserAccessRights = new HashSet<UserAccessRights>();
            UserDeviceInformations = new HashSet<UserDeviceInformations>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PhoneCountryCode { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public Guid? ImageMediaStoreId { get; set; }
        public Guid? ImageThumbnailMediaStoreId { get; set; }
        public bool? IsActive { get; set; }
        public bool IsBlocked { get; set; }
        public int? AccessRightTypeId { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Guid? DeletedBy { get; set; }
        public Guid? FkCustomerId { get; set; }
        public Guid UserTypeId { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public bool? IsMale { get; set; }

        public virtual AccessRightTypes? AccessRightType { get; set; }
        public virtual Customers? FkCustomer { get; set; }
        public virtual MediaStore? ImageMediaStore { get; set; }
        public virtual MediaStore? ImageThumbnailMediaStore { get; set; }
        public virtual UserType UserType { get; set; } = null!;
        public virtual ICollection<AdminUserRoles> AdminUserRoles { get; set; }
        public virtual ICollection<ClientBank> ClientBankAspNetUser { get; set; }
        public virtual ICollection<ClientBank> ClientBankCreatedByNavigation { get; set; }
        public virtual ICollection<ClientBank> ClientBankDeletedByNavigation { get; set; }
        public virtual ICollection<ClientBank> ClientBankModifiedByNavigation { get; set; }
        public virtual ICollection<ClientServices> ClientServicesCreatedByNavigation { get; set; }
        public virtual ICollection<ClientServices> ClientServicesDeletedByNavigation { get; set; }
        public virtual ICollection<ClientServices> ClientServicesModifiedByNavigation { get; set; }
        public virtual ICollection<Customers> CustomersCreatedByNavigation { get; set; }
        public virtual ICollection<Customers> CustomersDeletedByNavigation { get; set; }
        public virtual ICollection<Customers> CustomersLastModifiedByNavigation { get; set; }
        public virtual ICollection<CustomersSubscriptions> CustomersSubscriptionsCreatedByNavigation { get; set; }
        public virtual ICollection<CustomersSubscriptions> CustomersSubscriptionsDeletedByNavigation { get; set; }
        public virtual ICollection<CustomersSubscriptions> CustomersSubscriptionsLastModifiedByNavigation { get; set; }
        public virtual ICollection<DiscountedProducts> DiscountedProductsCreatedByNavigation { get; set; }
        public virtual ICollection<DiscountedProducts> DiscountedProductsDeletedByNavigation { get; set; }
        public virtual ICollection<DiscountedProducts> DiscountedProductsModifiedByNavigation { get; set; }
        public virtual ICollection<DiscountedServices> DiscountedServicesCreatedByNavigation { get; set; }
        public virtual ICollection<DiscountedServices> DiscountedServicesDeletedByNavigation { get; set; }
        public virtual ICollection<DiscountedServices> DiscountedServicesModifiedByNavigation { get; set; }
        public virtual ICollection<NotificationsSubscription> NotificationsSubscription { get; set; }
        public virtual ICollection<Product> ProductCreatedByNavigation { get; set; }
        public virtual ICollection<Product> ProductDeletedByNavigation { get; set; }
        public virtual ICollection<Product> ProductModifiedByNavigation { get; set; }
        public virtual ICollection<Roles> Roles { get; set; }
        public virtual ICollection<ShopCategory> ShopCategoryCreatedByNavigation { get; set; }
        public virtual ICollection<ShopCategory> ShopCategoryDeletedByNavigation { get; set; }
        public virtual ICollection<ShopCategory> ShopCategoryModifiedByNavigation { get; set; }
        public virtual ICollection<Shop> ShopCreatedByNavigation { get; set; }
        public virtual ICollection<Shop> ShopDeletedByNavigation { get; set; }
        public virtual ICollection<ShopGenderCategory> ShopGenderCategoryCreatedByNavigation { get; set; }
        public virtual ICollection<ShopGenderCategory> ShopGenderCategoryDeletedByNavigation { get; set; }
        public virtual ICollection<ShopGenderCategory> ShopGenderCategoryModifiedByNavigation { get; set; }
        public virtual ICollection<Shop> ShopModifiedByNavigation { get; set; }
        public virtual ICollection<Staff> StaffCreatedByNavigation { get; set; }
        public virtual ICollection<Staff> StaffDeletedByNavigation { get; set; }
        public virtual ICollection<Staff> StaffModifiedByNavigation { get; set; }
        public virtual ICollection<StaffOccupiedTime> StaffOccupiedTimeCreatedByNavigation { get; set; }
        public virtual ICollection<StaffOccupiedTime> StaffOccupiedTimeDeletedByNavigation { get; set; }
        public virtual ICollection<StaffOccupiedTime> StaffOccupiedTimeModifiedByNavigation { get; set; }
        public virtual ICollection<StaffSchedule> StaffScheduleCreatedByNavigation { get; set; }
        public virtual ICollection<StaffSchedule> StaffScheduleDeletedByNavigation { get; set; }
        public virtual ICollection<StaffSchedule> StaffScheduleModifiedByNavigation { get; set; }
        public virtual ICollection<StaffServices> StaffServicesCreatedByNavigation { get; set; }
        public virtual ICollection<StaffServices> StaffServicesDeletedByNavigation { get; set; }
        public virtual ICollection<StaffServices> StaffServicesModifiedByNavigation { get; set; }
        public virtual ICollection<UserAccessRights> UserAccessRights { get; set; }
        public virtual ICollection<UserDeviceInformations> UserDeviceInformations { get; set; }
    }
}
