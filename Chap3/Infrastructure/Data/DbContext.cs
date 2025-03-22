using Chap3.Domain;
using Microsoft.EntityFrameworkCore;

namespace Chap3.Repositories;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(order =>
        {
            order.HasKey(o => o.Id);

            order.HasOne(o => o.Customer)
                .WithMany()
                .HasForeignKey("CustomerId");

            order.OwnsMany(o => o.OrderItems, oi =>
            {
                oi.WithOwner().HasForeignKey("OrderId");
                oi.Property<int>("Id");
                oi.HasKey("Id");
            });
        });

        base.OnModelCreating(modelBuilder);
    }
}