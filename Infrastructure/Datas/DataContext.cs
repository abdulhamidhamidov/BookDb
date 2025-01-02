using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Datas;

public class DataContext(DbContextOptions<DataContext> options): DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Author>().HasMany<Book>(c => c.Books).WithOne(a => a.Author).HasForeignKey(a => a.AuthorId);
        modelBuilder.Entity<Publisher>().HasMany<Book>(c => c.Books).WithOne(a => a.Publisher).HasForeignKey(a => a.AuthorId);
    }
}