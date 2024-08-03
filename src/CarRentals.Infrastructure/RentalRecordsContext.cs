using CarRentals.Infrastructure.DbModels;
using Microsoft.EntityFrameworkCore;

namespace CarRentals.Infrastructure;

public class RentalRecordsContext(DbContextOptions<RentalRecordsContext> options) : DbContext(options)
{
    public DbSet<RentalRecord> RentalRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);
        modelBuilder.Entity<RentalRecord>().ToTable("RentalRecords");
    }
}