using Microsoft.EntityFrameworkCore;
using InvoiceWebAdmin.Models;

namespace InvoiceWebAdmin.Database;

public class AdminDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<CompanySettings> CompanySettings => Set<CompanySettings>();
    public DbSet<SubscriptionPeriod> SubscriptionPeriods => Set<SubscriptionPeriod>();
    public DbSet<AdminSettings> AdminSettings => Set<AdminSettings>();

    public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<CompanySettings>()
            .HasOne(cs => cs.User)
            .WithOne(u => u.CompanySettings)
            .HasForeignKey<CompanySettings>(cs => cs.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<SubscriptionPeriod>()
            .HasOne(sp => sp.User)
            .WithMany(u => u.SubscriptionPeriods)
            .HasForeignKey(sp => sp.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AdminSettings>()
            .Property(s => s.MonthlyPriceExclVat)
            .HasColumnType("decimal(18,2)");
    }
}
