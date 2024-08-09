using System.Net.Mime;
using Asp.Versioning;
using AutoMapper;
using BLL.App.Mappers;
using BLL.Contracts.App;
using BLL.DTO;
using DAL.App.EF;
using DAL.EF.App;
using Helpers.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Public.DTO.v1;

namespace WebApp.ApiControllers;

/// <summary>
/// Controller for Appointments booking and info
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiController]
public class PublicAppointmentController(
    ApplicationDbContext context,
    IAppBLL bll,
    IMapper autoMapper,
    ILogger<PublicAppointmentController> logger)
    : ControllerBase
{
    private readonly ApplicationDbContext _context = context;
    private readonly AutoMapper<Appointment, AppointmentBooking> _mapper = new(autoMapper);


    /// <summary>
    /// Get all Appointments
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpGet]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IEnumerable<AppointmentBooking>> GetAll()
    {
        var appointments = 
            await bll.AppointmentsService.AllAsync();
        var enumerable = appointments.ToList();
        var res = enumerable.Where(u => u.ClientId == User.GetUserId())
            .ToList();
        
        var mappedAppointments = res
            .Select(a => _mapper.Map(a));
            
        return mappedAppointments!;
    }
    
    /// <summary>
    /// Create a new Appointment
    /// </summary>
    /// <param name="appointment"></param>
    /// <returns></returns>
    [HttpPost]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(AppointmentBooking), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(RestApiErrorResponse), StatusCodes.Status400BadRequest)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<AppointmentBooking> CreateAppointment(AppointmentBooking appointment)
    {
        logger.LogWarning("Query received: {Appointment}", appointment);
        var newAppointment = _mapper.Map(appointment);
        if (newAppointment == null)
        {
            
        }
        var createdAppointment = await bll.AppointmentsService.CreateAppointment(newAppointment);
        logger.LogWarning("Created appointment {Appointment}", createdAppointment);
        return _mapper.Map(createdAppointment)!;
    }
    
    /// <summary>
    /// Gets an appointment by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the appointment to get.</param>
    /// <returns>An Appointment representing the result of the get operation.</returns>
    [HttpGet("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<AppointmentBooking> GetById(Guid id)
    {
        var a = bll.AppointmentsService.FindAsyncById(id, User.GetUserId())!;

        if (a != null)
        {
            return _mapper.Map(a)!;
        }
        
        logger.LogWarning("Get request fo appointment: {Id} ", id);
        return null!;
    }    
    
    [HttpPut]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<AppointmentBooking> Update(AppointmentBooking appointment)
    {
        logger.LogWarning("Query received: {Appointment}", appointment);
        var newAppointment = _mapper.Map(appointment);
        if (newAppointment == null)
        {
            
        }
        
        var createdAppointment = await bll.AppointmentsService.UpdateAppointment(newAppointment);
        logger.LogWarning("Updated appointment {Appointment}", createdAppointment);
        return _mapper.Map(createdAppointment)!;
    }


    /// <summary>
    /// Deletes an appointment by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the appointment to delete.</param>
    /// <returns>An IActionResult representing the result of the deletion operation.</returns>
    [HttpDelete("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> DeleteAppointment(Guid id)
    {
        await bll.AppointmentsService.RemoveAsync(id, User.GetUserId());
        
        logger.LogWarning("Deleted");
        return NoContent();
    }

}
