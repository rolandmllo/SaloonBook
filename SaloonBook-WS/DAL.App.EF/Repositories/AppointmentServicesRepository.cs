using App.Domain;
using DAL.Contracts.App;
using DAL.EF.Base;

namespace DAL.App.EF.Repositories;

public class AppointmentServicesRepository 
    : EFBaseRepository<AppointmentServices, ApplicationDbContext>, IAppointmentServicesRepository
{
    public AppointmentServicesRepository(ApplicationDbContext dataContext) : base(dataContext)
    {
    }
}