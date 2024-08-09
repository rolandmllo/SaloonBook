using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO;
using Contracts.Base;
using DAL.Contracts.App;
using Schedule = App.Domain.Schedule;

namespace BLL.App.Services;

public class EmployeeScheduleService : 
    BaseEntityService<BLL.DTO.EmployeeSchedule, Schedule, IScheduleRepository> , 
    IEmployeeScheduleService
{
    protected IAppUOW Uow;

    public EmployeeScheduleService(IAppUOW uow, IMapper<EmployeeSchedule, Schedule> mapper) : 
        base(uow.ScheduleRepository, mapper)
    {
        Uow = uow;
    }

    
}