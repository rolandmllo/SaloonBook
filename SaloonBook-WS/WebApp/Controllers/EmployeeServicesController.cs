using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Domain;
using DAL.App.EF;

namespace WebApp.Controllers
{
    public class EmployeeServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeServices
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EmployeeServices.Include(e => e.Employee).Include(e => e.Service);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EmployeeServices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeServices = await _context.EmployeeServices
                .Include(e => e.Employee)
                .Include(e => e.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeServices == null)
            {
                return NotFound();
            }

            return View(employeeServices);
        }

        // GET: EmployeeServices/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Users, "Id", "FirstName");
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "ServiceDescription");
            return View();
        }

        // POST: EmployeeServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,ServiceId,Id")] EmployeeServices employeeServices)
        {
            if (ModelState.IsValid)
            {
                employeeServices.Id = Guid.NewGuid();
                _context.Add(employeeServices);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Users, "Id", "FirstName", employeeServices.EmployeeId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "ServiceDescription", employeeServices.ServiceId);
            return View(employeeServices);
        }

        // GET: EmployeeServices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeServices = await _context.EmployeeServices.FindAsync(id);
            if (employeeServices == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Users, "Id", "FirstName", employeeServices.EmployeeId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "ServiceDescription", employeeServices.ServiceId);
            return View(employeeServices);
        }

        // POST: EmployeeServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("EmployeeId,ServiceId,Id")] EmployeeServices employeeServices)
        {
            if (id != employeeServices.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeServices);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeServicesExists(employeeServices.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Users, "Id", "FirstName", employeeServices.EmployeeId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "ServiceDescription", employeeServices.ServiceId);
            return View(employeeServices);
        }

        // GET: EmployeeServices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeServices = await _context.EmployeeServices
                .Include(e => e.Employee)
                .Include(e => e.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeServices == null)
            {
                return NotFound();
            }

            return View(employeeServices);
        }

        // POST: EmployeeServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var employeeServices = await _context.EmployeeServices.FindAsync(id);
            if (employeeServices != null)
            {
                _context.EmployeeServices.Remove(employeeServices);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeServicesExists(Guid id)
        {
            return _context.EmployeeServices.Any(e => e.Id == id);
        }
    }
}
