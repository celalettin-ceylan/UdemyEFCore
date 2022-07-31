using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace UdemyEFCore.CodeFirst.DAL;

public class AppDbContext : DbContext
{
    public DbSet<Product>? Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Initializer.Build();
        optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
    }

    public override int SaveChanges()
    {
        ChangeTracker.Entries().ToList().ForEach(p => {
            if (p.Entity is Product product)
            {
                if (p.State == EntityState.Added)
                {
                    product.CreatedDate = DateTime.Now;
                    Console.WriteLine($"{product.Id} : {product.Name} - {product.Price} - {product.Stock}");
                }
            }
        });
        return base.SaveChanges();
    }
}
