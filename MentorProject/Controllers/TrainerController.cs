using MentorProject.DAL;
using MentorProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MentorProject.Controllers
{
    public class TrainerController : Controller
    {
        private AppDbContext _context;

        public TrainerController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Trainer> trainers = _context.Trainers.Include(x=>x.Courses).Include(x=>x.Accounts).ToList();
            return View(trainers);
        }
    }
}
