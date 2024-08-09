using BLL.DTO;
using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;

public interface IServicesService : IBaseRepository<Service>, IServiceRepositoryCustom<Service>
{
    Task<IEnumerable<Service>> GetServiceListByCategoryId(Guid categoryId);
    Task<IEnumerable<Service>> FindServicesByCategoryIdAsync(Guid categoryId);


}