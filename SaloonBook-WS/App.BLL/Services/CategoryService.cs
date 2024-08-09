using App.Domain.Identity;
using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO;
using Contracts.Base;
using DAL.Contracts.App;
using Microsoft.AspNetCore.Identity;

namespace BLL.App.Services;

public class CategoryService : 
    BaseEntityService<BLL.DTO.Category, global::App.Domain.Category, ICategoryRepository>, ICategoryService
{
    protected IAppUOW Uow;
    private UserManager<AppUser> _userManager;

    public CategoryService(IAppUOW uow, 
        IMapper<Category, global::App.Domain.Category> mapper, UserManager<AppUser> userManager) : 
        base(uow.CategoryRepository, mapper)
    {
        Uow = uow;
        _userManager = userManager;
    }

    public async Task<IEnumerable<Category>> GetAllCategories()
    {
        return (await Uow.CategoryRepository.AllAsync()).Select(c => Mapper.Map(c)!);
    }
    
}