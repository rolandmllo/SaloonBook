using App.Domain;
using DAL.Contracts.App;
using DAL.Contracts.Base;
using DAL.EF.Base;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories;

public class CategoryRepository
    : EFBaseRepository<Category, ApplicationDbContext>, ICategoryRepository

{
    public CategoryRepository(ApplicationDbContext dataContext) : base(dataContext)
    {
    }
    
    
}