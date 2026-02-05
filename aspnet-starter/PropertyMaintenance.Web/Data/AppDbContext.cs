using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PropertyMaintenance.Web.Models;

namespace PropertyMaintenance.Web.Data;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<CustomerProfile> CustomerProfiles => Set<CustomerProfile>();
    public DbSet<Service> Services => Set<Service>();
    public DbSet<JobRequest> JobRequests => Set<JobRequest>();
    public DbSet<Quote> Quotes => Set<Quote>();
    public DbSet<Booking> Bookings => Set<Booking>();
    public DbSet<Job> Jobs => Set<Job>();
    public DbSet<JobStatusLog> JobStatusLogs => Set<JobStatusLog>();
    public DbSet<Attachment> Attachments => Set<Attachment>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<CustomerProfile>()
            .HasIndex(c => c.UserId)
            .IsUnique();

        builder.Entity<JobRequest>()
            .HasOne(r => r.Customer)
            .WithMany(c => c.JobRequests)
            .HasForeignKey(r => r.CustomerProfileId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<JobRequest>()
            .HasOne(r => r.Service)
            .WithMany()
            .HasForeignKey(r => r.ServiceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
