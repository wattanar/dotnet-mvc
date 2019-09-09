using Microsoft.EntityFrameworkCore;
using Web.Domain.Entities;

namespace Web.Data
{
  public class DataDbContext : DbContext
  {
    public DataDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Users> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Users>().HasData(
        new Users
        {
          Id = 1,
          Name = "Wattana Ruengmucha"
        });
    }
  }
}