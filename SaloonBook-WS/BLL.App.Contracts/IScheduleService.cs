using App.Domain;
using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;

public interface IScheduleService : IBaseRepository<Schedule>, IScheduleRepositoryCustom<DTO.Schedule>
{
    
}