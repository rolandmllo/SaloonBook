using BLL.DTO;
using DAL.Contracts.App;
using DAL.Contracts.Base;
using Appointment = App.Domain.Appointment;

namespace BLL.Contracts.App;

public interface IAppointmentsScheduleService : IBaseRepository<Appointment>, IAppointmentRepositoryCustom<Appointment>
{
    // add your custom service methods here
}
