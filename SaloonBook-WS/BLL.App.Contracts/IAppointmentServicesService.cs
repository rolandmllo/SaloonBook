using BLL.DTO;
using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;

public interface IAppointmentServicesService : IBaseRepository<AppointmentServices>, 
    IAppointmentRepositoryCustom<AppointmentServices>
{
    
}