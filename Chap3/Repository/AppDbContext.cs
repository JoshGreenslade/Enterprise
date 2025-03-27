using Microsoft.EntityFrameworkCore;
using Chap3.Domain;

namespace Chap3.Repositories;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Customer>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<Product>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<Order>(order =>
        {
            order.HasKey(o => o.Id);

            order.OwnsMany(o => o.OrderItems, oi =>
            {
                oi.WithOwner().HasForeignKey("OrderId");
                oi.Property<int>("Id");
                oi.HasKey("Id");

                oi.HasOne<Product>()
                    .WithMany()
                    .HasForeignKey("ProductId");

                oi.Property<int>("ProductId");
                oi.Property<int>(nameof(OrderItem.Quantity));

            });
        });

        base.OnModelCreating(modelBuilder);
    }

}