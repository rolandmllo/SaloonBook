using App.Domain.Identity;
using DAL.App.EF;
using DAL.App.EF.Seeding;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Tests;

public class CustomWebAppFactory<TStartup> : WebApplicationFactory<TStartup>
    where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);


        builder.ConfigureServices(services =>
        {
            // find DbContext
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<ApplicationDbContext>));

            // if found - remove
            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            // and new DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDbForTesting");
            });

            // create db and seed data
            var sp = services.BuildServiceProvider();
            using var scope = sp.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<ApplicationDbContext>();
            var logger = scopedServices
                .GetRequiredService<ILogger<CustomWebAppFactory<TStartup>>>();

            var usermanager = scopedServices.GetRequiredService<UserManager<AppUser>>();
            var roleManager = scopedServices.GetRequiredService<RoleManager<AppRole>>();
            db.Database.EnsureCreated();
            
            AppDataInit.SeedIdentity(usermanager, roleManager);
            AppDataInit.SeedAppData(db);
            
            
        });
    }
}