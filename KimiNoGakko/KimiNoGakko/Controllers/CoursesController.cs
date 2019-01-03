using KimiNoGakko.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KimiNoGakko.Controllers
{
    public class CoursesController : Controller
    {
        private readonly SchoolContext _context;

        public CoursesController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var schoolContext = _context.Courses.Include(c => c.Employee).Include(c => c.Subject);
            return View(await schoolContext.ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Employee)
                .Include(c => c.Subject)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            ViewData["EmployeeItems"] = new SelectList(_context.Employees, "ID", "FullName");
            ViewData["SubjectItems"] = new SelectList(_context.Subjects, "SubjectID", "Name");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseID,SubjectID,EmployeeID,EnrollmentID")] Course course)
        {

            var instructor = _context.Employees.Single(x => x.ID == course.EmployeeID);
            var subject = _context.Subjects.Single(x => x.SubjectID == course.SubjectID);
            if (ModelState.IsValid)
            {
                course.FullName = "[" + subject.Name + "] " + instructor.FullName;
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeItems"] = new SelectList(_context.Employees, "ID", "FirstMidName", course.EmployeeID);
            ViewData["SubjectID"] = new SelectList(_context.Subjects, "SubjectID", "SubjectID", course.SubjectID);
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(x => x.Employee)
                .Include(x => x.Subject)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["EmployeeItems"] = new SelectList(_context.Employees, "ID", "FullName", course.Employee.FullName);
            ViewData["SubjectItems"] = new SelectList(_context.Subjects, "SubjectID", "Name", course.Subject.Name);

            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Course course)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var isntructor = _context.Employees.Find(course.EmployeeID);
                    var subject = _context.Subjects.Find(course.SubjectID);
                    //_context.Courses.Update(course);
                    course.FullName = "[" + subject.Name + "] " + isntructor.FullName;
                    _context.Entry(course).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.ID))
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
            ViewData["EmployeeItems"] = new SelectList(_context.Employees, "ID", "FullName", course.EmployeeID);
            ViewData["SubjectID"] = new SelectList(_context.Subjects, "SubjectID", "SubjectID", course.SubjectID);
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Employee)
                .Include(c => c.Subject)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.SingleOrDefaultAsync(m => m.ID == id);
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.ID == id);
        }
    }
}
