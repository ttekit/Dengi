using System.Configuration;
using System.Windows;
using Dengi.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dengi.Core.DB;

public class DengiDBContext : DbContext
{
    private static readonly string _connectionString = "Data Source=mydatabase.db;";

    public DengiDBContext()
    {
        // Database.EnsureDeleted();
        // Database.EnsureCreated();
    }

    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(
            _connectionString);
    }

    public void AddCategory(Category category)
    {
        Add(category);
        SaveChanges();
    }

    public void RemoveCategory(Category category)
    {
        Remove(category);
        SaveChanges();
    }

    public void UpdateCategory(Category category)
    {
        
        Update(category);
        SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Category[] categories =
        {
            new Category { Id = 1, Name = "Продукты", ParentId = null },
            new Category { Id = 2, Name = "Товары", ParentId = null },
            new Category { Id = 3, Name = "Аптека", ParentId = null },
            new Category { Id = 4, Name = "Автомобиль", ParentId = null },
            new Category { Id = 5, Name = "Отдых", ParentId = null },
            new Category { Id = 6, Name = "Питомец", ParentId = null },
            new Category { Id = 7, Name = "Одежда", ParentId = 2 },
            new Category { Id = 8, Name = "Мебель", ParentId = 2 },
            new Category { Id = 9, Name = "Бытовая техника", ParentId = 2 },
            new Category { Id = 10, Name = "Топливо", ParentId = 4 },
            new Category { Id = 11, Name = "Ремонт", ParentId = 4 },
            new Category { Id = 12, Name = "ТО", ParentId = 4 },
        };

        modelBuilder.Entity<Category>().HasData(categories);
    }
}