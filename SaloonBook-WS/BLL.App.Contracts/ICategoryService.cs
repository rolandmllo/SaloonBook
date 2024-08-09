using BLL.DTO;
using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;

public interface ICategoryService : 
    IBaseRepository<BLL.DTO.Category>, ICategoryRepositoryCustom<BLL.DTO.Category>
{   
    public Task<IEnumerable<Category>> GetAllCategories();
    
}