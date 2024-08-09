using App.Domain.Identity;
using Asp.Versioning;
using AutoMapper;
using BLL.Contracts.App;
using DAL.App.EF;
using Microsoft.AspNetCore.Mvc;
using Public.DTO.v1;

namespace WebApp.ApiControllers;

/// <summary>
/// Public userInfo
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiController]
public class PublicUsersController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IAppBLL _bll;
    private readonly IMapper _mapper;

    /// <inheritdoc />
    public PublicUsersController(ApplicationDbContext context, IAppBLL bll, IMapper mapper)
    {
        _context = context;
        _bll = bll;
        _mapper = mapper;
    }

    /// <summary>
    /// Get all Employees by Service Id and Salon Id
    /// </summary>
    /// <param name="serviceId">Service Id</param>
    /// <param name="salonId">Salon Id</param>
    /// <returns>List of Employees</returns>
    [HttpGet("{serviceId:guid}/{salonId:guid}")]
    public IEnumerable<BasicUserInfo> GetEmployeeByServiceAndSalon(Guid serviceId, Guid salonId)
    {
        var employeeList = _bll.UsersService.GetEmployeeByServiceAndSalon(serviceId, salonId);

        return null!;
    }

    /// <summary>
    /// Get all employees
    /// </summary>
    /// <returns>List of Employees</returns>
    [HttpGet]
    public IEnumerable<BasicUserInfo> GetAllEmployees()
    {
        var employeeList = _bll.UsersService.GetAllEmployees();

        return employeeList.Result.Select(s => _mapper.Map<AppUser, BasicUserInfo>(s)).ToList();
    }
}