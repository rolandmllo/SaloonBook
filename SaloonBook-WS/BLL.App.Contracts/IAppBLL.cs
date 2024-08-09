using BLL.Contracts.Base;
using DAL.Contracts.App;

namespace BLL.Contracts.App;

public interface IAppBLL : IBaseBLL
{
    ISalonsService SalonsService { get; }
    
    IAppointmentsService AppointmentsService { get; }
    
    ICategoryService CategoryService { get; }
    
    IServicesService ServicesService { get; }
    
    IUsersService UsersService { get; }

}