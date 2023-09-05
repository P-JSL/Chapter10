using System;
using static System.Console;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared;

public  class Northwind : DbContext
{
    
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Product>? Products { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseLazyLoadingProxies();

        if(ProjectConstants.DatabaseProvider == "SQLite")
        {
            string path = Path.Combine(
                    Environment.CurrentDirectory, "Northwind.db"
                );
            WriteLine($"Using {path} database file.");
            optionsBuilder.UseSqlite( $"Filename={path}");
        }
        else
        {
            string connection = "Data Source=.; " + "Initial Catalog=Northwind; " + "Integerated Security=true; "
                + "MultipleActiveResultSets=true;";
            optionsBuilder.UseSqlite( connection );
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasQueryFilter(p => !p.Discontinued);

        // Fluent API 이용, 이름 15 제한
        modelBuilder.Entity<Category>()
                    .Property(category => category.CategoryName)
                    .IsRequired() // Not Null
                    .HasMaxLength(15);
        if(ProjectConstants.DatabaseProvider == "SQLite")
        {
            modelBuilder.Entity<Product>()
                    .Property(product => product.Cost)
                    .HasConversion<double>();
        }
    }

}
