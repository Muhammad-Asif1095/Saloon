using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class AspNetUsers
{
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

    public virtual ICollection<AdminUserRoles> AdminUserRoles { get; } = new List<AdminUserRoles>();

    public virtual ICollection<ClientBank> ClientBankAspNetUser { get; } = new List<ClientBank>();

    public virtual ICollection<ClientBank> ClientBankCreatedByNavigation { get; } = new List<ClientBank>();

    public virtual ICollection<ClientBank> ClientBankDeletedByNavigation { get; } = new List<ClientBank>();

    public virtual ICollection<ClientBank> ClientBankModifiedByNavigation { get; } = new List<ClientBank>();

    public virtual ICollection<ClientServices> ClientServicesCreatedByNavigation { get; } = new List<ClientServices>();

    public virtual ICollection<ClientServices> ClientServicesDeletedByNavigation { get; } = new List<ClientServices>();

    public virtual ICollection<ClientServices> ClientServicesModifiedByNavigation { get; } = new List<ClientServices>();

    public virtual ICollection<Customers> CustomersCreatedByNavigation { get; } = new List<Customers>();

    public virtual ICollection<Customers> CustomersDeletedByNavigation { get; } = new List<Customers>();

    public virtual ICollection<Customers> CustomersLastModifiedByNavigation { get; } = new List<Customers>();

    public virtual ICollection<CustomersSubscriptions> CustomersSubscriptionsCreatedByNavigation { get; } = new List<CustomersSubscriptions>();

    public virtual ICollection<CustomersSubscriptions> CustomersSubscriptionsDeletedByNavigation { get; } = new List<CustomersSubscriptions>();

    public virtual ICollection<CustomersSubscriptions> CustomersSubscriptionsLastModifiedByNavigation { get; } = new List<CustomersSubscriptions>();

    public virtual ICollection<DiscountedProducts> DiscountedProductsCreatedByNavigation { get; } = new List<DiscountedProducts>();

    public virtual ICollection<DiscountedProducts> DiscountedProductsDeletedByNavigation { get; } = new List<DiscountedProducts>();

    public virtual ICollection<DiscountedProducts> DiscountedProductsModifiedByNavigation { get; } = new List<DiscountedProducts>();

    public virtual ICollection<DiscountedServices> DiscountedServicesCreatedByNavigation { get; } = new List<DiscountedServices>();

    public virtual ICollection<DiscountedServices> DiscountedServicesDeletedByNavigation { get; } = new List<DiscountedServices>();

    public virtual ICollection<DiscountedServices> DiscountedServicesModifiedByNavigation { get; } = new List<DiscountedServices>();

    public virtual Customers? FkCustomer { get; set; }

    public virtual MediaStore? ImageMediaStore { get; set; }

    public virtual MediaStore? ImageThumbnailMediaStore { get; set; }

    public virtual ICollection<NotificationsSubscription> NotificationsSubscription { get; } = new List<NotificationsSubscription>();

    public virtual ICollection<Product> ProductCreatedByNavigation { get; } = new List<Product>();

    public virtual ICollection<Product> ProductDeletedByNavigation { get; } = new List<Product>();

    public virtual ICollection<Product> ProductModifiedByNavigation { get; } = new List<Product>();

    public virtual ICollection<Roles> Roles { get; } = new List<Roles>();

    public virtual ICollection<ShopCategory> ShopCategoryCreatedByNavigation { get; } = new List<ShopCategory>();

    public virtual ICollection<ShopCategory> ShopCategoryDeletedByNavigation { get; } = new List<ShopCategory>();

    public virtual ICollection<ShopCategory> ShopCategoryModifiedByNavigation { get; } = new List<ShopCategory>();

    public virtual ICollection<Shop> ShopCreatedByNavigation { get; } = new List<Shop>();

    public virtual ICollection<Shop> ShopDeletedByNavigation { get; } = new List<Shop>();

    public virtual ICollection<ShopGenderCategory> ShopGenderCategoryCreatedByNavigation { get; } = new List<ShopGenderCategory>();

    public virtual ICollection<ShopGenderCategory> ShopGenderCategoryDeletedByNavigation { get; } = new List<ShopGenderCategory>();

    public virtual ICollection<ShopGenderCategory> ShopGenderCategoryModifiedByNavigation { get; } = new List<ShopGenderCategory>();

    public virtual ICollection<Shop> ShopModifiedByNavigation { get; } = new List<Shop>();

    public virtual ICollection<Staff> StaffCreatedByNavigation { get; } = new List<Staff>();

    public virtual ICollection<Staff> StaffDeletedByNavigation { get; } = new List<Staff>();

    public virtual ICollection<Staff> StaffModifiedByNavigation { get; } = new List<Staff>();

    public virtual ICollection<StaffOccupiedTime> StaffOccupiedTimeCreatedByNavigation { get; } = new List<StaffOccupiedTime>();

    public virtual ICollection<StaffOccupiedTime> StaffOccupiedTimeDeletedByNavigation { get; } = new List<StaffOccupiedTime>();

    public virtual ICollection<StaffOccupiedTime> StaffOccupiedTimeModifiedByNavigation { get; } = new List<StaffOccupiedTime>();

    public virtual ICollection<StaffSchedule> StaffScheduleCreatedByNavigation { get; } = new List<StaffSchedule>();

    public virtual ICollection<StaffSchedule> StaffScheduleDeletedByNavigation { get; } = new List<StaffSchedule>();

    public virtual ICollection<StaffSchedule> StaffScheduleModifiedByNavigation { get; } = new List<StaffSchedule>();

    public virtual ICollection<StaffServices> StaffServicesCreatedByNavigation { get; } = new List<StaffServices>();

    public virtual ICollection<StaffServices> StaffServicesDeletedByNavigation { get; } = new List<StaffServices>();

    public virtual ICollection<StaffServices> StaffServicesModifiedByNavigation { get; } = new List<StaffServices>();

    public virtual ICollection<UserAccessRights> UserAccessRights { get; } = new List<UserAccessRights>();

    public virtual ICollection<UserDeviceInformations> UserDeviceInformations { get; } = new List<UserDeviceInformations>();

    public virtual UserType UserType { get; set; } = null!;
}
