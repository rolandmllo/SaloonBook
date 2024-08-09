using App.Domain;
using DAL.Contracts.App;
using DAL.EF.Base;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories;

public class ServiceRepository
    : EFBaseRepository<Service, ApplicationDbContext>, IServiceRepository

{
    public ServiceRepository(ApplicationDbContext dataContext) : base(dataContext)
    {
    }

    public async Task<IEnumerable<Service>> FindServicesByCategoryIdAsync(Guid categoryId)
    {
        return await RepositoryDbSet.Where(s => s.CategoryId.Equals(categoryId)).ToListAsync();
    }
}