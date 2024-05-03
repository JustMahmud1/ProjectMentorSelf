using MentorProject.DAL;
using MentorProject.Models;
using MentorProject.VMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MentorProject.Controllers
{
    public class HomeController : Controller
    {

        private AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Trainers= _context.Trainers.Include(x => x.Courses).Include(x => x.Accounts).ToList(),
                Courses = _context.Courses.Include(x => x.Trainer).ToList()
        };
            return View(homeVM);
        }


    }
}
