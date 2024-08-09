/*using App.Domain.Identity;
using BLL.App.Services;
using BLL.Contracts.App;
using Contracts.Base;
using DAL.App.EF;
using DAL.Contracts.App;
using Microsoft.AspNetCore.Identity;

using Appointment = App.Domain.Appointment;

namespace Tests.Unit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
// using WebApp.Api;
using Xunit.Abstractions;

public class ScheduleServiceTests
{

    private Mock<IAppointmentsRepository> _mockAppointmentsRepo;
    private Mock<IAppUOW> _mockUow;
    private Mock<UserManager<AppUser>> _mockUserManager;
    private Mock<IMapper<BLL.DTO.Appointment, Appointment>> _mockMapper;
    private AppointmentsScheduleService _service;

    private readonly ITestOutputHelper _testOutputHelper;
    private readonly ApplicationDbContext _ctx;
    private readonly Mock<IAppointmentsService> _AppointmentServiceMock;

    public ScheduleServiceTests
    {
        _mockAppointmentsRepo = new Mock<IAppointmentsRepository>();
        _mockUow = new Mock<IAppUOW>();
        _mockUserManager = new Mock<UserManager<AppUser>>(...);
        _mockMapper = new Mock<IMapper<BLL.DTO.Appointment, Appointment>>();
        _service = new AppointmentsScheduleService(_mockUow.Object, _mockMapper.Object, _mockUserManager.Object, ...);
    

        // set up mock database - inMemory
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        // use random guid as db instance id
        optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
        _ctx = new ApplicationDbContext(optionsBuilder.Options);

        // reset db
        _ctx.Database.EnsureDeleted();
        _ctx.Database.EnsureCreated();

        using var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var logger = logFactory.CreateLogger<AppointmentsScheduleService>();
        
        _AppointmentServiceMock = new Mock<IAppointmentsService>();


        // SUT
    }


 

}*/