using Microsoft.EntityFrameworkCore;
using ComicSystem.Models;
public class ComicSystemDbContext : DbContext
{
    public ComicSystemDbContext(DbContextOptions<ComicSystemDbContext> options) : base(options) { }

    public DbSet<ComicBook> ComicBooks { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<RentalDetail> RentalDetails { get; set; }
}
