using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Datas;

public class DataContext(DbContextOptions<DataContext> options): DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
}