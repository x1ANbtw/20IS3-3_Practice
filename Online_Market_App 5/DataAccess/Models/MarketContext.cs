using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Online_Market_App.Models
{
    public partial class MarketContext : DbContext
    {
        public MarketContext()
        {
        }

        public MarketContext(DbContextOptions<MarketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public virtual DbSet<Specification> Specifications { get; set; } = null!;
        public virtual DbSet<SpecsForProduct> SpecsForProducts { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-2LBF1EI;Database=Market;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.CartId)
                    .ValueGeneratedNever()
                    .HasColumnName("cart_id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.ProductCount).HasColumnName("product_count");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cart_Products");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cart_Users");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("order_id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("order_date");

                entity.Property(e => e.ProductCount).HasColumnName("product_count");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Products");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Order_status");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Users");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK__Order_st__3683B531D26FAE01");

                entity.ToTable("Order_status");

                entity.Property(e => e.StatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("status_id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(50)
                    .HasColumnName("status_name");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("product_id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");

                entity.Property(e => e.ProductCount).HasColumnName("product_count");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .HasColumnName("product_name");

                entity.Property(e => e.ProductPrice)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("product_price");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Product_category");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("Product_category");

                entity.Property(e => e.ProductCategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("product_category_id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.ProductCategoryName)
                    .HasMaxLength(50)
                    .HasColumnName("product_category_name");

                entity.Property(e => e.SpecId).HasColumnName("spec_id");

                entity.HasOne(d => d.Spec)
                    .WithMany(p => p.ProductCategories)
                    .HasForeignKey(d => d.SpecId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_category_Specification");
            });

            modelBuilder.Entity<Specification>(entity =>
            {
                entity.HasKey(e => e.SpecId)
                    .HasName("PK__Specific__F670C567ADF9717D");

                entity.ToTable("Specification");

                entity.Property(e => e.SpecId)
                    .ValueGeneratedNever()
                    .HasColumnName("spec_id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.SpecName)
                    .HasMaxLength(50)
                    .HasColumnName("spec_name");

                entity.Property(e => e.SpecValue).HasColumnName("spec_value");
            });

            modelBuilder.Entity<SpecsForProduct>(entity =>
            {
                entity.HasKey(e => e.SpecProductId);

                entity.ToTable("Specs_for_product");

                entity.Property(e => e.SpecProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("spec_product_id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.SpecId).HasColumnName("spec_id");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SpecsForProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Specs_for_product_Products");

                entity.HasOne(d => d.Spec)
                    .WithMany(p => p.SpecsForProducts)
                    .HasForeignKey(d => d.SpecId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Specs_for_product_Specification");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.Addres)
                    .HasMaxLength(50)
                    .HasColumnName("addres");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_User_roles");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__User_rol__760965CC51FF79F2");

                entity.ToTable("User_roles");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("role_id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .HasColumnName("role_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
