using App.Domain;
using DAL.Contracts.App;
using DAL.EF.Base;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories;

public class AppointmentRepository : EFBaseRepository<Appointment, ApplicationDbContext>, IAppointmentsRepository
{
    public AppointmentRepository(ApplicationDbContext dataContext) : base(dataContext)
    {
    }


public override async Task<IEnumerable<Appointment>> AllAsync()
    {
        return await RepositoryDbSet
            .Include(e => e.Employee)
            .Include(e => e.AppointmentServices)
            .Include(e => e.Salon)
            .Include(e => e.Client)
            .Include(e => e.Salon)
            .OrderBy(e => e.ReservationFrom)
            .ToListAsync();
    }

public async Task<IEnumerable<Appointment>> AppointmentsBySalonAndCategory(Guid salonId, Guid serviceId)
{
    return await RepositoryDbSet
        .Include(e => e.Employee)
        .Include(e => e.Client)
        .Include(e => e.Salon)
        .Include(s => s.AppointmentServices)
        .OrderBy(e => e.ReservationFrom)
        .Where(e => e.SalonId == salonId &&
                    e.AppointmentServices.Any(s => s.ServiceId == serviceId))
        .ToListAsync();
    
}

public async Task<IEnumerable<Appointment>> GetAppointmentsByEmployees(IEnumerable<EmployeeServices> employees)
{
    var employee =  employees;
    var employeeIds = employee.Select(e => e.EmployeeId);
    var appointments = RepositoryDbSet
        .Where(a => employeeIds.Contains(a.EmployeeId));
    return appointments ;
}




public virtual async Task<IEnumerable<Appointment>> AllAsyncByEMployee(Guid EmployeeId)
    {
        return await RepositoryDbSet
            .Include(e => e.Employee)
            .Include(e => e.Client)
            .Include(e => e.Salon)
            .OrderBy(e => e.ReservationFrom)
            .Where(t => t.EmployeeId == EmployeeId)
            .ToListAsync();
    }

    public override async Task<Appointment?> FindAsync(Guid id)
    {
        return await RepositoryDbSet
            //.AsNoTracking()
            .Include(t => t.Employee)
            .Include(e => e.Client)
            .Include(e => e.Salon)
            .Include(e => e.AppointmentServices)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public virtual async Task<Appointment?> FindAsync(Guid id, Guid clientId)
    {
        return await RepositoryDbSet
             .Include(t => t.Employee)
             .Include(t => t.Client)
             .FirstOrDefaultAsync( m => m.Client.Id == clientId);
    }

    public async Task<Appointment?> RemoveAsync(Guid id, Guid clientId)
    {
        var appointment = await FindAsync(id, clientId);
        return appointment == null ? null : Remove(appointment);
    }

    public async Task<bool> IsOwnedByUserAsync(Guid id, Guid clientId)
    {
        return await RepositoryDbSet.AnyAsync(t => t.Id == id && t.ClientId == clientId);
    }

}