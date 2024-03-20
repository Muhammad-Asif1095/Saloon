using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SaloonApp.Data.SaloonDB.DTO;

namespace SaloonApp.Data.SaloonDB
{
    public partial class SaloonDbContext : DbContext
    {
        public SaloonDbContext()
        {
        }

        public SaloonDbContext(DbContextOptions<SaloonDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccessRightTypes> AccessRightTypes { get; set; } = null!;
        public virtual DbSet<AdminUserRoles> AdminUserRoles { get; set; } = null!;
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; } = null!;
        public virtual DbSet<City> City { get; set; } = null!;
        public virtual DbSet<ClientBank> ClientBank { get; set; } = null!;
        public virtual DbSet<ClientServices> ClientServices { get; set; } = null!;
        public virtual DbSet<Country> Country { get; set; } = null!;
        public virtual DbSet<Customers> Customers { get; set; } = null!;
        public virtual DbSet<CustomersSubscriptions> CustomersSubscriptions { get; set; } = null!;
        public virtual DbSet<DeviceTypes> DeviceTypes { get; set; } = null!;
        public virtual DbSet<DiscountedProducts> DiscountedProducts { get; set; } = null!;
        public virtual DbSet<DiscountedServices> DiscountedServices { get; set; } = null!;
        public virtual DbSet<MediaStore> MediaStore { get; set; } = null!;
        public virtual DbSet<MediaType> MediaType { get; set; } = null!;
        public virtual DbSet<MediaTypesFormats> MediaTypesFormats { get; set; } = null!;
        public virtual DbSet<Notifications> Notifications { get; set; } = null!;
        public virtual DbSet<NotificationsSubscription> NotificationsSubscription { get; set; } = null!;
        public virtual DbSet<Product> Product { get; set; } = null!;
        public virtual DbSet<Province> Province { get; set; } = null!;
        public virtual DbSet<Rights> Rights { get; set; } = null!;
        public virtual DbSet<RoleRights> RoleRights { get; set; } = null!;
        public virtual DbSet<Roles> Roles { get; set; } = null!;
        public virtual DbSet<ScheduleDays> ScheduleDays { get; set; } = null!;
        public virtual DbSet<Shop> Shop { get; set; } = null!;
        public virtual DbSet<ShopCategory> ShopCategory { get; set; } = null!;
        public virtual DbSet<ShopGenderCategory> ShopGenderCategory { get; set; } = null!;
        public virtual DbSet<Staff> Staff { get; set; } = null!;
        public virtual DbSet<StaffOccupiedTime> StaffOccupiedTime { get; set; } = null!;
        public virtual DbSet<StaffSchedule> StaffSchedule { get; set; } = null!;
        public virtual DbSet<StaffServices> StaffServices { get; set; } = null!;
        public virtual DbSet<UserAccessRights> UserAccessRights { get; set; } = null!;
        public virtual DbSet<UserDeviceInformations> UserDeviceInformations { get; set; } = null!;
        public virtual DbSet<UserType> UserType { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=13.211.46.92;Initial Catalog=Saloon;Persist Security Info=False;User ID=sa;Password=Junaid@123;MultipleActiveResultSets=true", x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessRightTypes>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedOnDate).HasColumnType("date");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            });

            modelBuilder.Entity<AdminUserRoles>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedOnDate).HasColumnType("date");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.HasOne(d => d.AdminUser)
                    .WithMany(p => p.AdminUserRoles)
                    .HasForeignKey(d => d.AdminUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdminUserRoles_AdminUsers");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AdminUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdminUserRoles_Roles");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.FkCustomerId).HasColumnName("FK_Customer_Id");

                entity.Property(e => e.ImageMediaStoreId).HasColumnName("ImageMediaStoreID");

                entity.Property(e => e.ImageThumbnailMediaStoreId).HasColumnName("ImageThumbnailMediaStoreID");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsMale)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.PhoneCountryCode).HasMaxLength(10);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

                entity.HasOne(d => d.AccessRightType)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.AccessRightTypeId)
                    .HasConstraintName("FK_AspNetUsers_AccessRightTypes");

                entity.HasOne(d => d.FkCustomer)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.FkCustomerId)
                    .HasConstraintName("FK_AspNetUsers_Customers");

                entity.HasOne(d => d.ImageMediaStore)
                    .WithMany(p => p.AspNetUsersImageMediaStore)
                    .HasForeignKey(d => d.ImageMediaStoreId)
                    .HasConstraintName("FK_AspNetUsers_MediaStore");

                entity.HasOne(d => d.ImageThumbnailMediaStore)
                    .WithMany(p => p.AspNetUsersImageThumbnailMediaStore)
                    .HasForeignKey(d => d.ImageThumbnailMediaStoreId)
                    .HasConstraintName("FK_AspNetUsers_MediaStore1");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AspNetUsers_UserType");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.ProvinceId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<ClientBank>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccountName).HasMaxLength(100);

                entity.Property(e => e.AccountNumber).HasMaxLength(100);

                entity.Property(e => e.AspNetUserId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BankName).HasMaxLength(100);

                entity.Property(e => e.CityId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.AspNetUser)
                    .WithMany(p => p.ClientBankAspNetUser)
                    .HasForeignKey(d => d.AspNetUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientBank_AspNetUsers3");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.ClientBank)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientBank_Country");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ClientBankCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientBank_AspNetUsers");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.ClientBankDeletedByNavigation)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK_ClientBank_AspNetUsers1");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.ClientBankModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_ClientBank_AspNetUsers2");
            });

            modelBuilder.Entity<ClientServices>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ClientServicesCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientServices_AspNetUsers");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.ClientServicesDeletedByNavigation)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK_ClientServices_AspNetUsers1");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.ClientServicesModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_ClientServices_AspNetUsers2");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.MediaStoreId).HasColumnName("MediaStoreID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.CustomersCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customers_AspNetUsers");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.CustomersDeletedByNavigation)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK_Customers_AspNetUsers2");

                entity.HasOne(d => d.LastModifiedByNavigation)
                    .WithMany(p => p.CustomersLastModifiedByNavigation)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK_Customers_AspNetUsers1");

                entity.HasOne(d => d.MediaStore)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.MediaStoreId)
                    .HasConstraintName("FK_Customers_MediaStore");
            });

            modelBuilder.Entity<CustomersSubscriptions>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.PackageId).HasColumnName("PackageID");

                entity.Property(e => e.SignedOn).HasColumnType("datetime");

                entity.Property(e => e.ValidThrough).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.CustomersSubscriptionsCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomersSubscriptions_AspNetUsers");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomersSubscriptions)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CustomersSubscriptions_Customers");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.CustomersSubscriptionsDeletedByNavigation)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK_CustomersSubscriptions_AspNetUsers1");

                entity.HasOne(d => d.LastModifiedByNavigation)
                    .WithMany(p => p.CustomersSubscriptionsLastModifiedByNavigation)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK_CustomersSubscriptions_AspNetUsers2");
            });

            modelBuilder.Entity<DeviceTypes>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedOnDate).HasColumnType("date");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            });

            modelBuilder.Entity<DiscountedProducts>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.DiscountPercent).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.DiscountedProductsCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DiscountedProducts_AspNetUsers");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.DiscountedProductsDeletedByNavigation)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK_DiscountedProducts_AspNetUsers1");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.DiscountedProductsModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_DiscountedProducts_AspNetUsers2");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.DiscountedProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DiscountedProducts_Product");
            });

            modelBuilder.Entity<DiscountedServices>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.DiscountPercent).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.ClientServices)
                    .WithMany(p => p.DiscountedServices)
                    .HasForeignKey(d => d.ClientServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DiscountedServices_ClientServices");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.DiscountedServicesCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DiscountedServices_AspNetUsers");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.DiscountedServicesDeletedByNavigation)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK_DiscountedServices_AspNetUsers1");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.DiscountedServicesModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_DiscountedServices_AspNetUsers2");
            });

            modelBuilder.Entity<MediaStore>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.MediaName).HasMaxLength(500);

                entity.Property(e => e.MediaTypeId).HasColumnName("MediaTypeID");

                entity.Property(e => e.MediaUri).HasMaxLength(250);

                entity.HasOne(d => d.MediaType)
                    .WithMany(p => p.MediaStore)
                    .HasForeignKey(d => d.MediaTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MediaStore_MediaType");
            });

            modelBuilder.Entity<MediaType>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<MediaTypesFormats>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.MediaFormat).HasMaxLength(50);

                entity.Property(e => e.MediaTypesId).HasColumnName("MediaTypesID");

                entity.HasOne(d => d.MediaTypes)
                    .WithMany(p => p.MediaTypesFormats)
                    .HasForeignKey(d => d.MediaTypesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MediaTypesFormats_MediaType");
            });

            modelBuilder.Entity<Notifications>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<NotificationsSubscription>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AspNetUsersId).HasColumnName("AspNetUsersID");

                entity.Property(e => e.NotificationsId).HasColumnName("NotificationsID");

                entity.HasOne(d => d.AspNetUsers)
                    .WithMany(p => p.NotificationsSubscription)
                    .HasForeignKey(d => d.AspNetUsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotificationsSubscription_AspNetUsers");

                entity.HasOne(d => d.Notifications)
                    .WithMany(p => p.NotificationsSubscription)
                    .HasForeignKey(d => d.NotificationsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotificationsSubscription_Notifications");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ProductCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_AspNetUsers");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.ProductDeletedByNavigation)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK_Product_AspNetUsers1");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.ProductModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_Product_AspNetUsers2");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Province)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Province_Country");
            });

            modelBuilder.Entity<Rights>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedOnDate).HasColumnType("date");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            });

            modelBuilder.Entity<RoleRights>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedOnDate).HasColumnType("date");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.HasOne(d => d.Right)
                    .WithMany(p => p.RoleRights)
                    .HasForeignKey(d => d.RightId)
                    .HasConstraintName("FK_RoleRights_Rights");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleRights)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_RoleRights_Roles");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOnDate).HasColumnType("date");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Roles_AspNetUsers");
            });

            modelBuilder.Entity<ScheduleDays>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ShopCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shop_AspNetUsers");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.ShopDeletedByNavigation)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK_Shop_AspNetUsers1");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.ShopModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_Shop_AspNetUsers2");

                entity.HasOne(d => d.ShopCategory)
                    .WithMany(p => p.Shop)
                    .HasForeignKey(d => d.ShopCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shop_ShopCategory");

                entity.HasOne(d => d.ShopGenderCategory)
                    .WithMany(p => p.Shop)
                    .HasForeignKey(d => d.ShopGenderCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shop_ShopGenderCategory");
            });

            modelBuilder.Entity<ShopCategory>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ShopCategoryCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShopCategory_AspNetUsers");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.ShopCategoryDeletedByNavigation)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK_ShopCategory_AspNetUsers1");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.ShopCategoryModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_ShopCategory_AspNetUsers2");
            });

            modelBuilder.Entity<ShopGenderCategory>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ShopGenderCategoryCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShopGenderCategory_AspNetUsers");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.ShopGenderCategoryDeletedByNavigation)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK_ShopGenderCategory_AspNetUsers1");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.ShopGenderCategoryModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_ShopGenderCategory_AspNetUsers2");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Image).HasMaxLength(500);

                entity.Property(e => e.JobStartDate).HasColumnType("datetime");

                entity.Property(e => e.MobileNo).HasMaxLength(20);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Speciality).HasMaxLength(200);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.StaffCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Staff_AspNetUsers");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.StaffDeletedByNavigation)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK_Staff_AspNetUsers1");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.StaffModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_Staff_AspNetUsers2");
            });

            modelBuilder.Entity<StaffOccupiedTime>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.StaffOccupiedTimeCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StaffOccupiedTime_AspNetUsers");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.StaffOccupiedTimeDeletedByNavigation)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK_StaffOccupiedTime_AspNetUsers1");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.StaffOccupiedTimeModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_StaffOccupiedTime_AspNetUsers2");

                entity.HasOne(d => d.ScheduleDay)
                    .WithMany(p => p.StaffOccupiedTime)
                    .HasForeignKey(d => d.ScheduleDayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StaffOccupiedTime_ScheduleDays");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.StaffOccupiedTime)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StaffOccupiedTime_Staff");
            });

            modelBuilder.Entity<StaffSchedule>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.EndsOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.StartsFrom).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.StaffScheduleCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StaffSchedule_AspNetUsers");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.StaffScheduleDeletedByNavigation)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK_StaffSchedule_AspNetUsers1");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.StaffScheduleModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_StaffSchedule_AspNetUsers2");

                entity.HasOne(d => d.ScheduleDay)
                    .WithMany(p => p.StaffSchedule)
                    .HasForeignKey(d => d.ScheduleDayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StaffSchedule_ScheduleDays");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.StaffSchedule)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StaffSchedule_Staff");
            });

            modelBuilder.Entity<StaffServices>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.StaffServicesCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StaffServices_AspNetUsers");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.StaffServicesDeletedByNavigation)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK_StaffServices_AspNetUsers1");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.StaffServicesModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_StaffServices_AspNetUsers2");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.StaffServices)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StaffServices_ClientServices");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.StaffServices)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StaffServices_Staff");
            });

            modelBuilder.Entity<UserAccessRights>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedOnDate).HasColumnType("date");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.HasOne(d => d.AspNetUser)
                    .WithMany(p => p.UserAccessRights)
                    .HasForeignKey(d => d.AspNetUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAccessRights_AspNetUsers");
            });

            modelBuilder.Entity<UserDeviceInformations>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedOnDate).HasColumnType("date");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeviceToken).HasMaxLength(2000);

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.Version).HasMaxLength(300);

                entity.Property(e => e.VersionName).HasMaxLength(500);

                entity.HasOne(d => d.AppUser)
                    .WithMany(p => p.UserDeviceInformations)
                    .HasForeignKey(d => d.AppUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserDeviceInformations_AppUsers");

                entity.HasOne(d => d.DeviceType)
                    .WithMany(p => p.UserDeviceInformations)
                    .HasForeignKey(d => d.DeviceTypeId)
                    .HasConstraintName("FK_UserDeviceInformations_DeviceTypes");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
