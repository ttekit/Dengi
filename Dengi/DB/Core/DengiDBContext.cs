using Dengi.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dengi.Core.DB;

public class DengiDBContext : DbContext
{
    private static readonly string _connectionString = "Data Source=mydatabase.db;";

    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(
            _connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Category[] categories =
        {
            new() { Id = 1, Name = "Продукты", ParentId = null },
            new() { Id = 2, Name = "Товары", ParentId = null },
            new() { Id = 3, Name = "Аптека", ParentId = null },
            new() { Id = 4, Name = "Автомобиль", ParentId = null },
            new() { Id = 5, Name = "Отдых", ParentId = null },
            new() { Id = 6, Name = "Питомец", ParentId = null },
            new() { Id = 7, Name = "Одежда", ParentId = 2 },
            new() { Id = 8, Name = "Мебель", ParentId = 2 },
            new() { Id = 9, Name = "Бытовая техника", ParentId = 2 },
            new() { Id = 10, Name = "Топливо", ParentId = 4 },
            new() { Id = 11, Name = "Ремонт", ParentId = 4 },
            new() { Id = 12, Name = "ТО", ParentId = 4 }
        };

        modelBuilder.Entity<Category>().HasData(categories);
    }
}