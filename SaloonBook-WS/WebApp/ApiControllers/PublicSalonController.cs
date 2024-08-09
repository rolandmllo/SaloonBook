using Asp.Versioning;
using AutoMapper;
using BLL.Contracts.App;
using BLL.DTO;
using DAL.App.EF;
using Microsoft.AspNetCore.Mvc;
using Public.DTO.v1;

namespace WebApp.ApiControllers;

/// <summary>
/// Salon  API controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiController]
public class PublicSalonController : ControllerBase
{  
    private readonly ApplicationDbContext _context;
    private readonly IAppBLL _bll;
    private readonly IMapper _mapper;

    /// <inheritdoc />
    public PublicSalonController(ApplicationDbContext context, IAppBLL bll, IMapper mapper)
    {
        _context = context;
        _bll = bll;
        _mapper = mapper;
    }

    /// <summary>
    /// Get list of salons by Service ID
    /// </summary>
    /// <param name="serviceId"></param>
    /// <returns>List of Salons</returns>
    [HttpGet("{serviceId:guid}")]
    public IEnumerable<SalonsByCityNames> GetSalonsListByServiceId(Guid serviceId)
    {
        var salonsList = _bll.SalonsService.GetSalonsListByServiceId(serviceId)
            .Result
            .Select(s => _mapper.Map<SalonsByCityName, SalonsByCityNames>(s))
            .ToList();

        return salonsList;
    }    
    
    /// <summary>
    /// Get list of salons by City ID
    /// </summary>
    /// <returns>List of Salons</returns>
    [HttpGet]
    public IEnumerable<SalonsByCityNames> GetAllSalonsByCity()
    {
        var salonsList = _bll.SalonsService.GetSalonsListByServiceId(new Guid())
            .Result
            .Select(s => _mapper.Map<SalonsByCityName, SalonsByCityNames>(s))
            .ToList();

        return salonsList;
    }
}

