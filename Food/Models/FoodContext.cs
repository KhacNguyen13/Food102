using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Food.Models;

public partial class FoodContext : DbContext
{
    public FoodContext()
    {
    }

    public FoodContext(DbContextOptions<FoodContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BBlog> BBlogs { get; set; }

    public virtual DbSet<BBlogComment> BBlogComments { get; set; }

    public virtual DbSet<BCart> BCarts { get; set; }

    public virtual DbSet<BCategory> BCategories { get; set; }

    public virtual DbSet<BContact> BContacts { get; set; }

    public virtual DbSet<BMenu> BMenus { get; set; }

    public virtual DbSet<BOrder> BOrders { get; set; }

    public virtual DbSet<BOrderDetail> BOrderDetails { get; set; }

    public virtual DbSet<BProduct> BProducts { get; set; }

    public virtual DbSet<BProductReview> BProductReviews { get; set; }

    public virtual DbSet<BTestimonial> BTestimonials { get; set; }

    public virtual DbSet<BUser> BUsers { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BBlog>(entity =>
        {
            entity.HasKey(e => e.BlogId);

            entity.ToTable("b_Blog");

            entity.Property(e => e.BlogId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AuthorId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CategoryId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Comment).HasMaxLength(1000);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Image).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<BBlogComment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__b_BlogCo__C3B4DFCA37585ACE");

            entity.ToTable("b_BlogComment");

            entity.Property(e => e.BlogId)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Detail).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<BCart>(entity =>
        {
            entity.HasKey(e => e.CartId);

            entity.ToTable("b_Cart");

            entity.Property(e => e.CartId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ProductId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<BCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK_b_Categories");

            entity.ToTable("b_Category");

            entity.Property(e => e.CategoryId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CategoryName).HasMaxLength(255);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.ImageUrl).HasMaxLength(255);
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.ParentCategoryId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<BContact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK_b_Contact");

            entity.ToTable("b-Contact");

            entity.Property(e => e.ContactId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ContactID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EmailAddress).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<BMenu>(entity =>
        {
            entity.HasKey(e => e.MenuId);

            entity.ToTable("b_Menu");

            entity.Property(e => e.MenuId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Alias).HasMaxLength(255);
            entity.Property(e => e.Parent)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Position).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<BOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.ToTable("b_Orders");

            entity.Property(e => e.OrderId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AmountBeforeDiscount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DiscountId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.ShippingAddress).HasMaxLength(500);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<BOrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId);

            entity.ToTable("b_OrderDetails");

            entity.Property(e => e.OrderDetailId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.OrderId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ProductId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<BProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("b_Products");

            entity.Property(e => e.ProductId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CategoryId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CategoryProductId)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.ImageUrl).HasMaxLength(255);
            entity.Property(e => e.ProductName).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<BProductReview>(entity =>
        {
            entity.HasKey(e => e.ProductReviewId).HasName("PK__b_Produc__3963188094B4B2BA");

            entity.ToTable("b_ProductReview");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Detail).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.ProductId)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<BTestimonial>(entity =>
        {
            entity.HasKey(e => e.TestimonialId);

            entity.ToTable("b_Testimonial");

            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.ModifiedBy).HasMaxLength(150);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<BUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("b_Users");

            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
