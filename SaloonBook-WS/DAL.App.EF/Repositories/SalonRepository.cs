using App.Domain;
using DAL.Contracts.App;
using DAL.EF.Base;
using Microsoft.EntityFrameworkCore;
using Salon = App.Domain.Salon;

namespace DAL.App.EF.Repositories;

public class SalonRepository
    : EFBaseRepository<Salon, ApplicationDbContext>, ISalonRepository

{
    public SalonRepository(ApplicationDbContext dataContext) : base(dataContext)
    {
    }

    public async Task<Task<global::App.Domain.Salon?>> GetSalonByName(string salonName)
    {
        return RepositoryDbSet
            .Where(s => s.SalonName == salonName).FirstOrDefaultAsync();
    }
    
    
    public override async Task<IEnumerable<Salon>> AllAsync()
    {
        return await RepositoryDbSet.Include(s => s.City).ToListAsync();
    }
    

    //return Dal.Dtos.Salon
    public async Task<Salon?> AllAsyncWithCities()
    {
        return await RepositoryDbSet.Select(s => new global::App.Domain.Salon
            {
                Id = s.Id,
                City = s.City
                //CityName = s.City!.CityName,
                //Salon = AllAsync()
                
            })
            .FirstOrDefaultAsync();
    }
}