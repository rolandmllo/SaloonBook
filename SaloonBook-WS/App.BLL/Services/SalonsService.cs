using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO;
using Contracts.Base;
using DAL.Contracts.App;

namespace BLL.App.Services;

public class SalonsService : BaseEntityService<Salon, global::App.Domain.Salon, ISalonRepository>, ISalonsService
{
    private readonly IAppUOW _uow;

    public SalonsService(IAppUOW uow, IMapper<Salon, global::App.Domain.Salon> mapper) : base(uow.SalonRepository, mapper)
    {
        _uow = uow;
    }

    public async Task<IEnumerable<SalonsByCityName>> GetSalonsListByServiceId(Guid serviceId)
    {
        var cities = await _uow.CityRepository.AllAsync();
        var salonsList = await _uow.SalonRepository.AllAsync();

        var res = cities.Select(city => new SalonsByCityName()
            {
                Id = city.Id,
                City = city.CityName,
                Salons = salonsList.Where(s => s.City.Id.Equals(city.Id))
                    .Select(a => Mapper.Map(a))
                    .ToList()!
            })
            .ToList();
        return res;
    }
}
