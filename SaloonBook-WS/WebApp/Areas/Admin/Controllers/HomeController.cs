using DAL.App.EF;
using DAL.EF.App;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.Controllers;

[Area("Admin")]
public class HomeController : Controller
{
    private readonly ILogger<WebApp.Controllers.HomeController> _logger;
    private readonly ApplicationDbContext _context;
    public HomeController(ILogger<WebApp.Controllers.HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    
}