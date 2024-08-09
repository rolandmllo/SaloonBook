using BLL.DTO;
using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;

public interface ISalonsService : IBaseRepository<BLL.DTO.Salon>, ISalonRepositoryCustom<BLL.DTO.Service>
{
    Task<IEnumerable<SalonsByCityName>> GetSalonsListByServiceId(Guid serviceId);
}