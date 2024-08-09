using App.Domain.Identity;
using AutoMapper;
using BLL.App.Mappers;
using BLL.App.Services;
using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO;
using DAL.Contracts.App;
using Microsoft.AspNetCore.Identity;

namespace BLL.App;

public class AppBLL : BaseBLL<IAppUOW>, IAppBLL
{
    private readonly IAppUOW _uow;
    private readonly IMapper _mapper;
    private UserManager<AppUser> _userManager;


    public AppBLL(IAppUOW uow, IMapper mapper, UserManager<AppUser> userManager) : base(uow)
    {
        _uow = uow;
        _mapper = mapper;
        _userManager = userManager;
    }

    private ISalonsService? _salons;
    private IAppointmentsService? _appointmentsService;
    private ICategoryService? _categoryService;
    private IServicesService? _servicesService;
    private IUsersService? _usersService;
    
    public ISalonsService SalonsService =>
        _salons ??= new SalonsService(_uow, new SalonsMapper(_mapper));
    
    public IAppointmentsService AppointmentsService =>
        _appointmentsService ??= new AppointmentsScheduleService(_uow, 
            new AppointmentMapper<Appointment, global::App.Domain.Appointment>(_mapper), _userManager, this);
    
    public ICategoryService CategoryService =>
        _categoryService ??= new CategoryService(_uow, 
            new CategoryMapper(_mapper), _userManager);

    public IServicesService ServicesService => _servicesService ??= new ServicesService(_uow,
        new ServiceMapper(_mapper));

    public IUsersService UsersService => _usersService ??= new UsersService(_uow, _userManager);
}