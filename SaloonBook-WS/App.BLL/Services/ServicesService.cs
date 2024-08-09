using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO;
using Contracts.Base;
using DAL.Contracts.App;

namespace BLL.App.Services;

public class ServicesService :  BaseEntityService<BLL.DTO.Service, global::App.Domain.Service, IServiceRepository>, IServicesService
{
    private readonly IAppUOW _uow;

    public ServicesService(IAppUOW uow, IMapper<Service, global::App.Domain.Service> mapper) : base(uow.ServiceRepository, mapper)
    {
        _uow = uow;
    }


    public async Task<IEnumerable<Service>> GetServiceListByCategoryId(Guid categoryId)
    {
        return (await _uow.ServiceRepository.FindServicesByCategoryIdAsync(categoryId))
            .Select(s => Mapper.Map(s))!;
    }

    public async Task<IEnumerable<Service>> FindServicesByCategoryIdAsync(Guid categoryId)
    {
        return (await _uow.ServiceRepository.FindServicesByCategoryIdAsync(categoryId))
            .Select(s => Mapper.Map(s))!;
    }
}