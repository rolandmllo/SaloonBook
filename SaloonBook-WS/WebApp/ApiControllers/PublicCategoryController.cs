using Asp.Versioning;
using AutoMapper;
using BLL.Contracts.App;
using DAL.App.EF;
using Microsoft.AspNetCore.Mvc;
using Public.DTO.Mappers;
using Public.DTO.v1;

namespace WebApp.ApiControllers;

/// <summary>
/// Public category controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiController]
public class PublicCategoryController(ApplicationDbContext context, IAppBLL bll, IMapper autoMapper)
    : ControllerBase
{
    private readonly CategoryMapper _mapper = new(autoMapper);

    /// <summary>
    /// Get all Categories
    /// </summary>
    /// <returns>List of categories</returns>
    [HttpGet]
    public async Task<IEnumerable<Category>> GetAll()
    {
        var categories = 
            await bll.CategoryService.AllAsync();

        return categories.Select(c => _mapper.Map(c)!).ToList();
    }
    
}