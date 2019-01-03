using KimiNoGakko.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KimiNoGakko.Controllers
{
    public class PresencesController : Controller
    {
        private readonly SchoolContext _context;

        public PresencesController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Presences
        public async Task<IActionResult> Index()
        {
            var schoolContext = _context.Presence.Include(p => p.Course).Include(p => p.Employee).Include(p => p.Student);
            return View(await schoolContext.ToListAsync());
        }

        // GET: Presences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presence = await _context.Presence
                .Include(p => p.Course)
                .Include(p => p.Employee)
                .Include(p => p.Student)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (presence == null)
            {
                return NotFound();
            }

            return View(presence);
        }

        // GET: Presences/Create
        public IActionResult Create()
        {
            ViewData["CourseID"] = new SelectList(_context.Courses, "ID", "FullName");
            ViewData["StudentID"] = new SelectList(_context.Students, "ID", "FullName");
            return View();
        }

        // POST: Presences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Data,Godzina,IsPresent,StudentID,CourseID")] Presence presence)
        {
            if (ModelState.IsValid)
            {
                Course course = _context.Courses.Single(x => x.ID == presence.CourseID);
                Employee employee = _context.Employees.Single(x => x.ID == course.EmployeeID);
                presence.EmployeeID = employee.ID;
                _context.Add(presence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseID"] = new SelectList(_context.Subjects, "ID", "FullName", presence.CourseID);
            ViewData["StudentID"] = new SelectList(_context.Students, "ID", "FullName", presence.StudentID);
            return View(presence);
        }

        // GET: Presences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presence = await _context.Presence.SingleOrDefaultAsync(m => m.ID == id);
            if (presence == null)
            {
                return NotFound();
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "ID", "FullName", presence.CourseID);
            ViewData["StudentID"] = new SelectList(_context.Students, "ID", "FullName", presence.StudentID);
            return View(presence);
        }

        // POST: Presences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Data,Godzina,IsPresent,StudentID,CourseID")] Presence presence)
        {
            if (id != presence.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Course course = _context.Courses.Single(x => x.ID == presence.CourseID);
                    Employee employee = _context.Employees.Single(x => x.ID == course.EmployeeID);
                    presence.EmployeeID = employee.ID;
                    _context.Update(presence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PresenceExists(presence.ID))
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
            ViewData["CourseID"] = new SelectList(_context.Courses, "ID", "FullName", presence.CourseID);
            ViewData["StudentID"] = new SelectList(_context.Students, "ID", "FullName", presence.StudentID);
            return View(presence);
        }

        // GET: Presences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presence = await _context.Presence
                .Include(p => p.Course)
                .Include(p => p.Employee)
                .Include(p => p.Student)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (presence == null)
            {
                return NotFound();
            }

            return View(presence);
        }

        // POST: Presences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var presence = await _context.Presence.SingleOrDefaultAsync(m => m.ID == id);
            _context.Presence.Remove(presence);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PresenceExists(int id)
        {
            return _context.Presence.Any(e => e.ID == id);
        }
    }
}
