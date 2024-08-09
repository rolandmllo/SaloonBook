using Asp.Versioning;
using AutoMapper;
using BLL.Contracts.App;
using DAL.App.EF;
using DAL.App.EF.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Public.DTO.Mappers;
using Public.DTO.v1;
using AppointmentScheduleByEmployeeName = BLL.DTO.AppointmentScheduleByEmployeeName;

namespace WebApp.ApiControllers;

/// <summary>
/// Public schedule controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiController]

public class PublicScheduleController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IAppBLL _bll;
    private readonly CategoryMapper _mapper;


    /// <summary>
    /// Public schedule controller constructor
    /// </summary>
    /// <param name="context"></param>
    /// <param name="bll"></param>
    /// <param name="autoMapper"></param>
    public PublicScheduleController(ApplicationDbContext context, IAppBLL bll, IMapper autoMapper)
    {
        _context = context;
        _bll = bll;
        _mapper = new CategoryMapper(autoMapper);
    }

    /// <summary>
    /// Get appointments
    /// </summary>
    /// <param name="category"></param>
    /// <param name="salon"></param>
    /// <returns>List of appointments</returns>
    [HttpGet("{category}/{salon}")]
    public async Task<IEnumerable<AppointmentScheduleByEmployeeName>> GetAppointmentsByDayAndCategories(
        string category, string salon)
    {
        //var salonId = await _bll.SalonsService.GetSalonIdByNameAsync(salon);
        //var serviceId = await _bll.ServicesService.GetServiceIdByNameAsync(service);

        var appointment = 
            await _bll.AppointmentsService.GetPublicSchedulesByEmployee(category, salon);
        
        if (_context.Appointments == null)
        {
        }
        //var appointment = await _context.Appointments.FindAsync(id);
        
    
        return appointment;

    }
  
    // DELETE: api/Appointment/5
    /// <summary>
    /// Delete a appointment
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Action result</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAppointment(Guid id)
    {
        if (_context.Appointments == null)
        {
            return NotFound();
        }
        var appointment = await _context.Appointments.FindAsync(id);
        if (appointment == null)
        {
            return NotFound();
        }

        _context.Appointments.Remove(appointment);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AppointmentExists(Guid id)
    {
        return (_context.Appointments?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}