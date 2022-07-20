using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using CRM.Models;
namespace CRM{



public class CRMContext : DbContext
{
    public DbSet<Seller> Sellers {get; set;}
    public DbSet<Customer> Customers { get; set; }

    public CRMContext(DbContextOptions<CRMContext> options): base(options){ }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Seller> sellersInit = new List<Seller>();
        sellersInit.Add(new Seller {SellerId= 1,SellerName = "Brayan" });


        modelBuilder.Entity<Seller>( seller =>
        {
            seller.ToTable("SellersDB");
            seller.HasKey(p => p.SellerId);
            seller.Property(p=>p.SellerName).IsRequired().HasMaxLength(150);
            seller.HasData(sellersInit);
       
        });

        modelBuilder.Entity<Customer>(customer =>
        {
            customer.ToTable("CustomersDB");
            customer.HasKey(p => p.CustomerId);
            customer.Property(p => p.CustomerName).IsRequired().HasMaxLength(150);
            customer.HasOne(p => p.AsignedSeller).WithMany(p => p.Customers).HasForeignKey(p => p.SellerId);
        });
    }
}
}

 