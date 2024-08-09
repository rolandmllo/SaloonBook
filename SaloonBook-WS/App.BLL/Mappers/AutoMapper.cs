using AutoMapper;
using DAL.Base;

namespace BLL.App.Mappers;

public class AutoMapper<TEntityIn, TEntityOut> : BaseMapper<TEntityIn, TEntityOut>
{
    public AutoMapper(IMapper mapper) : base(mapper)
    {
    }
}