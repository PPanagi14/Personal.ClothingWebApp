using Microsoft.EntityFrameworkCore;
using ClothingWebApp.Domain.Entities;

namespace ClothingWebApp.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Brand> Brands { get; set; }
        //public DbSet<Size> Sizes { get; set; }
        //public DbSet<Color> Colors { get; set; }
        //public DbSet<Stock> Stocks { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderItem> OrderItems { get; set; }
        //public DbSet<Cart> Carts { get; set; }
        //public DbSet<CartItem> CartItems { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            //    modelBuilder.Entity<Category>().ToTable("Categories");
            //    modelBuilder.Entity<Brand>().ToTable("Brands");
            //    modelBuilder.Entity<Size>().ToTable("Sizes");
            //    modelBuilder.Entity<Color>().ToTable("Colors");
            //    modelBuilder.Entity<Stock>().ToTable("Stocks");
            //    modelBuilder.Entity<Order>().ToTable("Orders");
            //    modelBuilder.Entity<OrderItem>().ToTable("OrderItems");
            //    modelBuilder.Entity<Cart>().ToTable("Carts");
            //    modelBuilder.Entity<CartItem>().ToTable("CartItems");
            //    modelBuilder.Entity<User>().ToTable("Users");
            //    modelBuilder.Entity<Role>().ToTable("Roles");
            //    modelBuilder.Entity<UserRole>().ToTable("UserRoles");
            //    modelBuilder.Entity<Product>()
            //        .HasOne(p => p.Category)
            //        .WithMany(c => c.Products)
            //        .HasForeignKey(p => p.CategoryId);
            //    modelBuilder.Entity<Product>()
            //        .HasOne(p => p.Brand)
            //        .WithMany(b => b.Products)
            //        .HasForeignKey(p => p.BrandId);
            //    modelBuilder.Entity<Product>()
            //        .HasOne(p => p.Size)
            //        .WithMany(s => s.Products)
            //        .HasForeignKey(p => p.SizeId);
            //    modelBuilder.Entity<Product>()
            //        .HasOne(p => p.Color)
            //        .WithMany(c => c.Products)
            //        .HasForeignKey(p => p.ColorId);
            //    modelBuilder.Entity<Stock>()
            //        .HasOne(s => s.Product)
            //        .WithMany(p => p.Stocks)
            //        .HasForeignKey(s => s.ProductId);
            //    modelBuilder

        }
    }
}
