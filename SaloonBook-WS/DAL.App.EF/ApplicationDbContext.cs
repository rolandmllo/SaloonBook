using App.Domain;
using App.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF;

public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    public DbSet<City> Cities { get; set; } = default!;
    public DbSet<Category> Categories { get; set; } = default!;
    public DbSet<Salon> Salons { get; set; } = default!;
    public DbSet<Service> Services { get; set; } = default!;
    
    public DbSet<Schedule> Schedules { get; set; } = default!;
    public DbSet<Appointment> Appointments { get; set; } = default!;
    
    public DbSet<AppointmentServices> AppointmentServices { get; set; } = default!;
    
    public DbSet<EmployeeServices> EmployeeServices { get; set; } = default!;
    
    public DbSet<AppRefreshToken> AppRefreshTokens { get; set; } = default!;
    
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // disable cascade delete
        foreach (var relationship in builder.Model
                     .GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
        
        builder.Entity<Appointment>()
            .HasOne(a => a.Employee)
            .WithMany()
            .HasForeignKey(a => a.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);        
        
        builder.Entity<Appointment>()
            .HasOne(a => a.Client)
            .WithMany()
            .HasForeignKey(a => a.ClientId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<Appointment>()
            .HasMany(a => a.AppointmentServices!)
            .WithOne(a=>a.Appointment!)
            .OnDelete(DeleteBehavior.Cascade);  
        
    }
    


}