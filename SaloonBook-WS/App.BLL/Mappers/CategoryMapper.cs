using AutoMapper;
using BLL.DTO;
using DAL.Base;

namespace BLL.App.Mappers;

public class CategoryMapper: BaseMapper<Category, global::App.Domain.Category>

{
    public CategoryMapper(IMapper mapper) : base(mapper)
    {
    }
    
}