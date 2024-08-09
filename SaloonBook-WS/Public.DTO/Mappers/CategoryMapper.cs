using App.Domain;
using AutoMapper;
using DAL.Base;
using Appointment = BLL.DTO.Appointment;

namespace Public.DTO.Mappers;

public class CategoryMapper : BaseMapper<BLL.DTO.Category, Public.DTO.v1.Category>
{
    public CategoryMapper(IMapper mapper) : base(mapper)
    {
        
    }



    // public v1.Category Map(IEnumerable<Appointment?> category)
    // {
    //     var res = Mapper.Map<v1.Category>(category);
    //     return res;
    // }
}