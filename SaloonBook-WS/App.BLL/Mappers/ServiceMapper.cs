using AutoMapper;
using BLL.DTO;
using DAL.Base;

namespace BLL.App.Mappers;

public class ServiceMapper : BaseMapper<Service, global::App.Domain.Service>
{
    public ServiceMapper(IMapper mapper) : base(mapper)
    {
    }
}