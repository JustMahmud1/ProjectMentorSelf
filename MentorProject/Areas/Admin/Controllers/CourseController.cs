using MentorProject.DAL;
using MentorProject.Models;
using MentorProject.Utilities.Extensions;
using MentorProject.VMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MentorProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private AppDbContext _context;
        private IWebHostEnvironment _env;

        public CourseController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index(int page = 1)
        {
            var query = _context.Courses.Include(x => x.Trainer).OrderByDescending(x => x.Id);
            return View(PaginatedList<Course>.Create(query, page, 3));
        }

        public IActionResult Create()
        {
            ViewBag.Trainers = _context.Trainers.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Trainers = _context.Trainers.ToList();
                return View(course);
            }
            course.ImageName = course.ImageFile.CreateFile(_env.WebRootPath, "assets/img");
            _context.Courses.Add(course);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Course course = _context.Courses.Find(id);
			course.ImageFile.DeleteFile(_env.WebRootPath, "assets/img", course.ImageName);
			_context.Courses.Remove(course);
            _context.SaveChanges();
            return Ok();
        }
    }
}
