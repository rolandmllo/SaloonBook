using App.Domain;
using AutoMapper;
using DAL.Base;

namespace BLL.App.Mappers;

public class SalonsMapper : BaseMapper<BLL.DTO.Salon, Salon>
{
    public SalonsMapper(IMapper mapper) : base(mapper)
    {
    }
}