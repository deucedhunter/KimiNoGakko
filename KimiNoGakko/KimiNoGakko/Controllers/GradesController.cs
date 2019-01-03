using KimiNoGakko.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KimiNoGakko.Controllers
{
    public class GradesController : Controller
    {
        private readonly SchoolContext _context;

        public GradesController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Grades
        public async Task<IActionResult> Index()
        {
            var schoolContext = _context.Grades.Include(g => g.Course).Include(g => g.Employee).Include(g => g.Student);
            return View(await schoolContext.ToListAsync());
        }

        // GET: Grades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = await _context.Grades
                .Include(g => g.Course)
                .Include(g => g.Employee)
                .Include(g => g.Student)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        // GET: Grades/Create
        public IActionResult Create()
        {
            ViewData["CourseID"] = new SelectList(_context.Courses, "ID", "FullName");
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "ID", "FullName");
            ViewData["StudentID"] = new SelectList(_context.Students, "ID", "FullName");
            var list = GenerateGradeList();
            ViewData["GradeList"] = new SelectList(list);
            return View();
        }

        // POST: Grades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Value,StudentID,EmployeeID,CourseID")] Grade grade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "ID", "FullName", grade.CourseID);
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "ID", "FullName", grade.EmployeeID);
            ViewData["StudentID"] = new SelectList(_context.Students, "ID", "FullName", grade.StudentID);
            var list = GenerateGradeList();
            ViewData["GradeList"] = new SelectList(list);
            return View(grade);
        }

        // GET: Grades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = await _context.Grades.SingleOrDefaultAsync(m => m.ID == id);
            if (grade == null)
            {
                return NotFound();
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "ID", "FullName", grade.CourseID);
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "ID", "FullName", grade.EmployeeID);
            ViewData["StudentID"] = new SelectList(_context.Students, "ID", "FullName", grade.StudentID);

            var list = GenerateGradeList();
            ViewData["GradeList"] = new SelectList(list, grade.Value);
            return View(grade);
        }

        // POST: Grades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Value,StudentID,EmployeeID,CourseID")] Grade grade)
        {
            if (id != grade.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GradeExists(grade.ID))
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
            ViewData["CourseID"] = new SelectList(_context.Courses, "ID", "FullName", grade.CourseID);
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "ID", "FullName", grade.EmployeeID);
            ViewData["StudentID"] = new SelectList(_context.Students, "ID", "FullName", grade.StudentID);
            var list = GenerateGradeList();
            ViewData["GradeList"] = new SelectList(list);
            return View(grade);
        }

        // GET: Grades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = await _context.Grades
                .Include(g => g.Course)
                .Include(g => g.Employee)
                .Include(g => g.Student)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        // POST: Grades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grade = await _context.Grades.SingleOrDefaultAsync(m => m.ID == id);
            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GradeExists(int id)
        {
            return _context.Grades.Any(e => e.ID == id);
        }

        private List<decimal> GenerateGradeList()
        {
            List<decimal> list = new List<decimal>();
            decimal tmp = (decimal)1.5;
            for (int i = 0; i < 7; i++)
            {
                tmp += (decimal)0.5;
                list.Add(tmp);
            }

            return list;
        }
    }
}
