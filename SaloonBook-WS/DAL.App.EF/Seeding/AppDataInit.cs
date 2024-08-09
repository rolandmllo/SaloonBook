using App.Domain;
using App.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Seeding;

public static class AppDataInit
{
    private static Guid adminId = Guid.Parse("bc7458ac-cbb0-4ecd-be79-d5abf19f8c77");
    private static Guid user1Id = Guid.Parse("74029690-33c6-4bf9-a520-df9902b41c5c");
    private static Guid user2Id = Guid.Parse("e8799e9b-4d34-4c46-a79d-45689bb1c9aa");
    private static Guid user3Id = Guid.Parse("60753bcf-814e-49fe-9c96-d044e50965c9");
    private static Guid juuksurId = new ("dbf07617-ef5a-466f-ac4a-f5b8b71d5cbc");
    private static Guid manikyyrId = new ("7128652b-9b7f-4e7d-9ae3-13735c891ae2");
    private static Guid tallinnGuid = new ("a248301e-975a-48bf-b3a2-b38bdbd6c00c");
    private static Guid tartuGuid = new ("e4479a41-b7b7-4fc5-94b6-109860751167");
    

    public static void MigrateDatabase(ApplicationDbContext context)
    {
        context.Database.Migrate();
    }
    
    

    public static void DropDatabase(ApplicationDbContext context)
    {
        context.Database.EnsureDeleted();
    }

    public static void SeedIdentity(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    {
        
        //Add Roles
        var adminRole =  roleManager.CreateAsync(new AppRole(EUserRole.Admin.ToString())).Result;
        var employeeRole =  roleManager.CreateAsync(new AppRole(EUserRole.Employee.ToString())).Result;
        var clientRole =  roleManager.CreateAsync(new AppRole(EUserRole.Client.ToString())).Result;
        


        (Guid id, string email, string pwd) userData = (adminId, "admin@app.com", "Foo.bar.1");
        var user = userManager.FindByEmailAsync(userData.email).Result;
        
        if (user == null)
        {
            user = new AppUser()
            {
                Id = userData.id,
                Email = userData.email,
                UserName = userData.email,
                FirstName = "Admin",
                LastName = "App",
                EmailConfirmed = true,
                Phone = "123",
            };
            var result = userManager.CreateAsync(user, userData.pwd).Result;
            var roleResult = userManager.AddToRoleAsync(user, EUserRole.Admin.ToString()).Result;
            if (!result.Succeeded)
            {
                throw new ApplicationException($"Cannot seed users, {result.ToString()}");
            }

            (Guid id, string email, string pwd) user1Data = (user1Id, "employee1@app.com", "Foo.bar.1");
            var user1 = userManager.FindByEmailAsync(user1Data.email).Result;
            if (user1 == null)
            {
                user1 = new AppUser()
                {
                    Id = user1Data.id,
                    Email = user1Data.email,
                    UserName = user1Data.email,
                    FirstName = "Maire",
                    LastName = "Käär",
                    EmailConfirmed = true,
                    Phone = "123456"
                };
                var u4 = userManager.CreateAsync(user1, user1Data.pwd).Result;
                var u5 = userManager.AddToRoleAsync(user1, nameof(EUserRole.Employee)).Result;

                (Guid id, string email, string pwd) user2Data = (user2Id, "employee2@app.com", "Foo.bar.1");
                var user2 = userManager.FindByEmailAsync(user2Data.email).Result;
                if (user2 == null)
                {
                    user2 = new AppUser()
                    {
                        Id = user2Data.id,
                        Email = user2Data.email,
                        UserName = user2Data.email,
                        FirstName = "Janne",
                        LastName = "Maasikas",
                        EmailConfirmed = true,
                        Phone = "1234567"
                    };
                    var u1 = userManager.CreateAsync(user2, user1Data.pwd).Result;
                    var u3 = userManager.AddToRoleAsync(user2, nameof(EUserRole.Admin)).Result;


                    (Guid id, string email, string pwd) user3Data = (user3Id, "user1@app.com", "Foo.bar.1");
                    var user3 = userManager.FindByEmailAsync(user3Data.email).Result;
                    if (user3 == null)
                    {
                        user3 = new AppUser()
                        {
                            Id = user3Data.id,
                            Email = user3Data.email,
                            UserName = user3Data.email,
                            FirstName = "Klient1",
                            LastName = "Name1",
                            EmailConfirmed = true,
                            Phone = "1234567"
                        };
                        var u6 = userManager.CreateAsync(user3, user3Data.pwd).Result;
                        var u7 = userManager.AddToRoleAsync(user3, nameof(EUserRole.Client)).Result;
                    }
                }
            }
        }
    }

    public static void SeedAppData(ApplicationDbContext context)
    {

        SeedAppDataServicesAndCategories(context);
        SeedAppDataSalonsAndCities(context);
        context.SaveChanges();
    }

    private static void SeedAppDataServices(ApplicationDbContext context)
    {
        if (context.Services.Any()) return;

    }

    private static void SeedAppDataSalonsAndCities(ApplicationDbContext context)
    {
        if (context.Salons.Any() || context.Cities.Any()) return;

        City tallinn = new City()
        {
            Id = tallinnGuid,
            CityName = "Tallinn"
        };
                
        City tartu = new City()
        {
            Id = tartuGuid,
            CityName = "Tartu"
        };
        context.Cities.Add(tallinn);
        context.Cities.Add(tartu);

        Salon salon1 = new Salon()
        {
            SalonName = "Mari Juures",
            SalonAddress = "Pärna 32",
            SalonEmail = "marijuures@hot.ee",
            SalonPhone = "55649856",
            City = tallinn,
        };
        context.Salons.Add(salon1);        
        
        Salon salon2 = new Salon()
        {
            SalonName = "Kaunid Küüned OÜ",
            SalonAddress = "Männi tee 44",
            SalonEmail = "kaunid.kyyned@gmail.com",
            SalonPhone = "571924322",
            City = tartu
        };
        context.Salons.Add(salon2);
    }

    private static void SeedAppDataServicesAndCategories(ApplicationDbContext context)
    {

        // Add Categories
        if (context.Services.Any() || context.Categories.Any()) return;
        Category juuksur = new Category()
        {
            Id = juuksurId,
            CategoryName = "Juuksur",
            Description = "Juuksuriteenused"
        };
        context.Categories.Add(juuksur);
                
        Category manikyyr = new Category()
        {
            Id = manikyyrId,
            CategoryName = "Maniküür",
            Description = "Küüntehooldus"
        };
        context.Categories.Add(manikyyr);
        
        
        // Add services
        Service meesteLoikus = new Service()
        {
            ServiceName = "Meeste lõikus",
            ServiceDescription = "Meeste juukslõikus",
            Duration = 0.5,
            Price = 15,
            CategoryId = juuksurId,
        };    
        context.Services.Add(meesteLoikus);
        
        Service naisteLoikus = new Service()
        {
            ServiceName = "Test Service",
            ServiceDescription = "Test service",
            Duration = 1.0,
            Price = 25,
            CategoryId = juuksurId,
        };
        context.Services.Add(naisteLoikus);

        Service manikyyrLakita = new Service()
        {
            ServiceName = "Maniküür lakita",
            ServiceDescription = "Küüntehooldus ilma lakita",
            Duration = 0.5,
            Price = 20,
            CategoryId = manikyyrId,
        };
        context.Services.Add(manikyyrLakita);        
        
        Service manikyyrGel = new Service()
        {
            ServiceName = "Maniküür geellakkimisega",
            ServiceDescription = "Küüntehooldus geellakkiga",
            Duration = 1.5,
            Price = 40,
            CategoryId = manikyyrId,
        };
        context.Services.Add(manikyyrLakita);
    }
}