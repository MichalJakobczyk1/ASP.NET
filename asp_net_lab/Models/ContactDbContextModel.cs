using Microsoft.EntityFrameworkCore;

namespace Lab1.Models
{
    public class ContactDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public string DbPath { get; set; }
        public ContactDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "contacts.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
            new Contact() { Id = 1, Name = "Filip", Age = 17, Email = "filip@gmail.com" },
            new Contact() { Id = 2, Name = "Bartek", Age = 20, Email = "bartek@gmail.com" },
            new Contact() { Id = 3, Name = "Dawid", Age = 30, Email = "dawid@gmail.com" },
            new Contact() { Id = 4, Name = "Kacper", Age = 45, Email = "kacper@gmail.com" },
            new Contact() { Id = 5, Name = "Ola", Age = 17, Email = "ola@gmail.com" },
            new Contact() { Id = 6, Name = "Michał", Age = 28, Email = "michał@gmail.com" },
            new Contact() { Id = 7, Name = "Jakub", Age = 29, Email = "jakub@gmail.com" },
            new Contact() { Id = 8, Name = "Tymek", Age = 46, Email = "tymek@gmail.com" },
            new Contact() { Id = 9, Name = "Konrad", Age = 31, Email = "konrad@gmail.com" },
            new Contact() { Id = 10, Name = "Kamil", Age = 15, Email = "kamil@gmail.com" },
            new Contact() { Id = 11, Name = "Dawid", Age = 80, Email = "dawid@gmail.com" },
            new Contact() { Id = 12, Name = "Daniel", Age = 76, Email = "daniel@gmail.com" }
                );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder
       options)
        => options.UseSqlite($"Data Source={DbPath}");
    }

}
