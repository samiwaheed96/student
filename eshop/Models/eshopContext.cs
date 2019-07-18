using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eshop.Models
{
    public partial class eshopContext : DbContext
    {
        public eshopContext()
        {
        }

        public eshopContext(DbContextOptions<eshopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SystemCategory> SystemCategory { get; set; }
        public virtual DbSet<SystemItem> SystemItem { get; set; }
        public virtual DbSet<SystemUser> SystemUser { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-4VVTE4A\\SQLEXPRESS;Database=eshop;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SystemCategory>(entity =>
            {
                entity.ToTable("system_category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modified_by")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Picture)
                    .HasColumnName("picture")
                    .HasMaxLength(500);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SystemItem>(entity =>
            {
                entity.ToTable("system_item");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CostPice)
                    .HasColumnName("cost_pice")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.ItemCategory).HasColumnName("item_category");

                entity.Property(e => e.ItemCode)
                    .HasColumnName("item_code")
                    .HasMaxLength(50);

                entity.Property(e => e.MainImage)
                    .HasColumnName("main_image")
                    .HasColumnType("text");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modified_by")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.SalePrice)
                    .HasColumnName("sale_price")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SystemUser>(entity =>
            {
                entity.ToTable("system_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DisplayName)
                    .HasColumnName("display_name")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modified_by")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.ProfilePicture)
                    .HasColumnName("profile_picture")
                    .HasColumnType("text");

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50);
            });
        }
    }
}
