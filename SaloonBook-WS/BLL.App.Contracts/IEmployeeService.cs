using BLL.DTO;
using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;

public interface IEmployeeServicesService : IBaseRepository<EmployeeServices>, 
    IEmployeeServiceRepositoryCustom<EmployeeServices>
{
    
}