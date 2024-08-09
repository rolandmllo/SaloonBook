using Asp.Versioning;
using AutoMapper;
using BLL.App.Mappers;
using BLL.Contracts.App;
using DAL.App.EF;
using Microsoft.AspNetCore.Mvc;
using Public.DTO.v1;
using Service = BLL.DTO.Service;

namespace WebApp.ApiControllers;

/// <summary>
/// Public category controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiController]
public class PublicServiceController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IAppBLL _bll;
    private readonly AutoMapper<Service, Service> _mapper;
    
    /// <summary>
    /// Constructor for public service
    /// </summary>
    /// <param name="context">DB context</param>
    /// <param name="bll">BLL services</param>
    /// <param name="autoMapper">Mapper instance</param>
    public PublicServiceController(ApplicationDbContext context, IAppBLL bll, IMapper autoMapper)
    {
        _context = context;
        _bll = bll;
        _mapper = new AutoMapper<Service, Service>(autoMapper);
    }
    
    /// <summary>
    /// Get a categories by ID
    /// </summary>
    /// <param name="categoryId">Categoriy ID</param>
    /// <returns>Category</returns>
    [HttpGet("{categoryId:guid}")]
    public async Task<IEnumerable<ServiceList>> GetByCategoryId(Guid categoryId)
    {
        var serviceList = _bll.ServicesService.GetServiceListByCategoryId(categoryId);

        return (await serviceList).Select(c => 
            new ServiceList()
            {
                Id = c.Id,
                ServiceName = c.ServiceName
            }).ToList();
    }    
    
    
    
}