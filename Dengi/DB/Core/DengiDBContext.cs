using System.Configuration;
using Dengi.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dengi.Core.DB;

public class DengiDBContext : DbContext
{
    private static readonly string _connectionString = "Data Source=mydatabase.db;Version=3;";

    public DengiDBContext()
    {
        Database.EnsureCreated();
    }

    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(
            ConfigurationManager.ConnectionStrings["Dengi"].ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Category[] categories =
        {
            new() { Id = 1, Name = "test", ParentId = null },
            new() { Id = 2, Name = "test", ParentId = null },
            new() { Id = 3, Name = "test", ParentId = null },
            new() { Id = 4, Name = "test", ParentId = null },
            new() { Id = 5, Name = "test", ParentId = null },
            new() { Id = 6, Name = "test", ParentId = null },
            new() { Id = 7, Name = "test", ParentId = null },
            new() { Id = 8, Name = "test", ParentId = null },
            new() { Id = 9, Name = "test", ParentId = null },
            new() { Id = 10, Name = "test", ParentId = null },
            new() { Id = 11, Name = "test", ParentId = null },
            new() { Id = 12, Name = "test", ParentId = null },
            new() { Id = 13, Name = "test", ParentId = null }
        };

        modelBuilder.Entity<Category>().HasData(categories);
    }
}