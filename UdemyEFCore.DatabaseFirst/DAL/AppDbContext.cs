using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace UdemyEFCore.DatabaseFirst.DAL;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {

    }

    // type of initializer 1
    public AppDbContext( DbContextOptions<AppDbContext> options) : base(options)
    {
            
    }
    public DbSet<Product> Products { get; set; }

    // type of initializer 2
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(DbContenxtInitializer.Configuration.GetConnectionString("SqlCon"));
        base.OnConfiguring(optionsBuilder);
    }
}
