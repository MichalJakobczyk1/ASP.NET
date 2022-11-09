using Microsoft.EntityFrameworkCore;

namespace Lab1.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public string DbPath { get; set; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "books.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                    new Book() { Id = 1, Title = "Harry Potter", Author = "J.K Rowling" },
                    new Book() { Id = 2, Title = "Lalka", Author = "Bolesław Prus" }
                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder
            options) 
            => options.UseSqlite($"Data Source = {DbPath}");
    }
}
