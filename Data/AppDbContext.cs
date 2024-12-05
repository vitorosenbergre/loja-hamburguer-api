using Microsoft.EntityFrameworkCore;

namespace MyEFProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSets (suas tabelas)
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Status> Status { get; set; } = null!;
        public DbSet<OrderProduct> OrderProducts { get; set; } = null!;
        public DbSet<UserOrder> UserOrders { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relacionamento entre Product e Category (Muitos-para-Um)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)           // Relação de Product para Category
                .WithMany(c => c.Products)         // Categoria pode ter muitos produtos
                .HasForeignKey(p => p.CategoryId)  // A chave estrangeira para Category
                .OnDelete(DeleteBehavior.Cascade); // Comportamento de deleção em cascata

            // Relacionamento entre Order e Status (Muitos-para-Um)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Status)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração para UserOrder
            modelBuilder.Entity<UserOrder>()
                .HasKey(uo => new { uo.UserId, uo.OrderId });

            modelBuilder.Entity<UserOrder>()
                .HasOne(uo => uo.User)
                .WithMany(u => u.UserOrders)
                .HasForeignKey(uo => uo.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Comportamento de deleção em cascata

            modelBuilder.Entity<UserOrder>()
                .HasOne(uo => uo.Order)
                .WithMany(o => o.UserOrders)
                .HasForeignKey(uo => uo.OrderId)
                .OnDelete(DeleteBehavior.Cascade); // Comportamento de deleção em cascata

            // Configuração para OrderProduct
            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.ProductId, op.OrderId });

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductId)
                .OnDelete(DeleteBehavior.Cascade); // Comportamento de deleção em cascata

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId)
                .OnDelete(DeleteBehavior.Cascade); // Comportamento de deleção em cascata
        }
    }
}
