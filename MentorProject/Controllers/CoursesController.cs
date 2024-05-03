using MentorProject.DAL;
using MentorProject.Models;
using MentorProject.VMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MentorProject.Controllers
{
    public class CoursesController : Controller
    {
        private AppDbContext _context;

        public CoursesController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page=1)
        {
            var query = _context.Courses.Include(x => x.Trainer);
            return View(PaginatedList<Course>.Create(query, page, 3));
        }

    }
}
