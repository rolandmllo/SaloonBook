using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Domain;
using DAL.App.EF;

namespace WebApp.Controllers
{
    public class AppointmentServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AppointmentServices
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AppointmentServices.Include(a => a.Appointment).Include(a => a.Service);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AppointmentServices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentServices = await _context.AppointmentServices
                .Include(a => a.Appointment)
                .Include(a => a.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointmentServices == null)
            {
                return NotFound();
            }

            return View(appointmentServices);
        }

        // GET: AppointmentServices/Create
        public IActionResult Create()
        {
            ViewData["AppointmentId"] = new SelectList(_context.Appointments, "Id", "Id");
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "ServiceDescription");
            return View();
        }

        // POST: AppointmentServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointmentId,ServiceId,Id")] AppointmentServices appointmentServices)
        {
            if (ModelState.IsValid)
            {
                appointmentServices.Id = Guid.NewGuid();
                _context.Add(appointmentServices);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppointmentId"] = new SelectList(_context.Appointments, "Id", "Id", appointmentServices.AppointmentId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "ServiceDescription", appointmentServices.ServiceId);
            return View(appointmentServices);
        }

        // GET: AppointmentServices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentServices = await _context.AppointmentServices.FindAsync(id);
            if (appointmentServices == null)
            {
                return NotFound();
            }
            ViewData["AppointmentId"] = new SelectList(_context.Appointments, "Id", "Id", appointmentServices.AppointmentId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "ServiceDescription", appointmentServices.ServiceId);
            return View(appointmentServices);
        }

        // POST: AppointmentServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("AppointmentId,ServiceId,Id")] AppointmentServices appointmentServices)
        {
            if (id != appointmentServices.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointmentServices);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentServicesExists(appointmentServices.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppointmentId"] = new SelectList(_context.Appointments, "Id", "Id", appointmentServices.AppointmentId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "ServiceDescription", appointmentServices.ServiceId);
            return View(appointmentServices);
        }

        // GET: AppointmentServices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentServices = await _context.AppointmentServices
                .Include(a => a.Appointment)
                .Include(a => a.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointmentServices == null)
            {
                return NotFound();
            }

            return View(appointmentServices);
        }

        // POST: AppointmentServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var appointmentServices = await _context.AppointmentServices.FindAsync(id);
            if (appointmentServices != null)
            {
                _context.AppointmentServices.Remove(appointmentServices);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentServicesExists(Guid id)
        {
            return _context.AppointmentServices.Any(e => e.Id == id);
        }
    }
}
