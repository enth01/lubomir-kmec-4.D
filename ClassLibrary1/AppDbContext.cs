using ClassLibrary1.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CartItemEntity> CartItems { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<UserAddressEntity> UserAddresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var basePath = Path.GetFullPath(
                    Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\ClassLibrary1")
                );
                var dbPath = Path.Combine(basePath, "appdata.db");

                optionsBuilder.UseSqlite($"Data Source={dbPath}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductEntity>()
            .Property(p => p.Categories)
            .HasConversion(
                v => string.Join(',', v),
                v => v == "" ? new List<int>() : v.Split(',', StringSplitOptions.None).Select(int.Parse).ToList()
            );
        }
    }
}
