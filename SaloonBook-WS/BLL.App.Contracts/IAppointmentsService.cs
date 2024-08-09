using BLL.DTO;
using DAL.Contracts.App;
using DAL.Contracts.Base;
using Public.DTO.v1;
using AppointmentScheduleByEmployeeName = BLL.DTO.AppointmentScheduleByEmployeeName;

namespace BLL.Contracts.App;

public interface IAppointmentsService 
    : IBaseRepository<BLL.DTO.Appointment> 
        , IAppointmentRepositoryCustom<BLL.DTO.Appointment>

{
    public Task<AppointmentScheduleByEmployeeName> AppointmentsByServiceAndSalon(Guid employeeName, 
        Guid categorieId);

    public Task<IEnumerable<AppointmentScheduleByEmployeeName>> GetPublicSchedulesByEmployee(string categoryName,
        string salonName);

    Task<Appointment> CreateAppointment(Appointment appointment);

    Task<bool> RemoveAsync(Guid id, Guid userId);
    Appointment? FindAsyncById(Guid id, Guid getUserId);
    Task<Appointment> UpdateAppointment(Appointment? newAppointment);
}