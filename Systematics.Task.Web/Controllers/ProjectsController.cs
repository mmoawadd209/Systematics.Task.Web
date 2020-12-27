using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Systematics.Task.Web.Models;

namespace Systematics.Task.Web.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly SystematicsDbContext _context;

        public ProjectsController(SystematicsDbContext context)
        {
            _context = context;
        }

        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public async Task<IActionResult> Index()
        {
            var systematicsDbContext = _context.Projects.Include(p => p.Status);
            return View(await systematicsDbContext.ToListAsync());
        }


        // GET: Projects/Create
        [HttpGet]
        public IActionResult Create()
        {
            var project = new Project();
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "ProjectStatus");
            return PartialView("_CreatePartial", project);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Project project)
        {
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "ProjectStatus", project.StatusId);

            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
            }
            var projects = _context.Projects.Include(p => p.Status);

            return View(nameof(Index), projects);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "ProjectStatus", project.StatusId);
            return PartialView("_EditPartial", project);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Project project)
        {
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "ProjectStatus", project.StatusId);

            if (id != project.Id)
                return NotFound();


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Id))
                        return NotFound();
                    else
                        throw;
                }
            }

                var projects = _context.Projects.Include(p => p.Status);

                return View(nameof(Index), projects);

        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return PartialView("_DeletePartial", project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            var projects = _context.Projects.Include(p => p.Status);

            return View(nameof(Index), projects);
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
