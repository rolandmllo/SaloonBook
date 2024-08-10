using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DAL.App.EF;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        // does not actually connect to db

        optionsBuilder.UseNpgsql("Host=localhost:5445;Username=postgres;Password=postgres;Database=saloon-book-db");
        // does not actually connect to db
        //optionsBuilder.UseNpgsql("");
        return new ApplicationDbContext(optionsBuilder.Options);
    }
    
    /*public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlite("Data Source=app.db");

        return new ApplicationDbContext(optionsBuilder.Options);    }*/
    
}