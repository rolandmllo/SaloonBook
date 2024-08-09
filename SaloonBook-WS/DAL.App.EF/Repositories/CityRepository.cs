using App.Domain;
using DAL.Contracts.App;
using DAL.EF.Base;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories;

public class CityRepository
    : EFBaseRepository<City, ApplicationDbContext>, ICityRepository

{
    public CityRepository(ApplicationDbContext dataContext) : base(dataContext)
    {
    }
    
    public override async Task<IEnumerable<City>> AllAsync()
    {
        return await _repositoryDbContext.Cities.Include(c => c.Salons).ToListAsync();
    }
}