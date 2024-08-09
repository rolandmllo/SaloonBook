using App.Domain;
using BLL.DTO;
using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;

public interface IEmployeeScheduleService    : 
    IBaseRepository<EmployeeSchedule>, IScheduleRepositoryCustom<EmployeeSchedule>
{
    
}