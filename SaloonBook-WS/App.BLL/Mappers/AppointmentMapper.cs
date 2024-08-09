using App.Domain;
using AutoMapper;
using DAL.Base;

namespace BLL.App.Mappers;

public class AppointmentMapper<TInObject, TOutObject> : BaseMapper<TInObject, TOutObject>
    where TOutObject : class, new()
    where TInObject : class, new()
{
    public AppointmentMapper(IMapper mapper) : base(mapper)
    {
        
    }
    
    
}