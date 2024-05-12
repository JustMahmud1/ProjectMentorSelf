using MentorProject.DAL;
using MentorProject.Models;
using MentorProject.VMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MentorProject.Controllers
{
	public class CoursesController : Controller
	{
		private AppDbContext _context;

		public CoursesController(AppDbContext context)
		{
			_context = context;
		}
		public IActionResult Index(int page = 1)
		{
			var query = _context.Courses.Include(x => x.Trainer);
			return View(PaginatedList<Course>.Create(query, page, 3));
		}

		public IActionResult AddBasket(int courseId)
		{	

			List<BasketCookieItemVM> cookieList = null;

			if (HttpContext.Request.Cookies["Courses"] != null)
			{
				cookieList = JsonConvert.DeserializeObject<List<BasketCookieItemVM>>(HttpContext.Request.Cookies["Courses"]);
			}
			else
			{
				cookieList = new List<BasketCookieItemVM>();
			}

			var existCookie = cookieList.FirstOrDefault(x => x.CourseId == courseId);

			if (existCookie != null)
			{
				existCookie.Count++;
			}
			else
			{
				BasketCookieItemVM cookieItem = new BasketCookieItemVM()
				{
					CourseId = courseId,
					Count = 1
				};
				cookieList.Add(cookieItem);
			}

			HttpContext.Response.Cookies.Append("Courses", JsonConvert.SerializeObject(cookieList));
			return RedirectToAction("Index");
		}

		public IActionResult GetCookie()
		{
			var item = HttpContext.Request.Cookies["Courses"];
			return Content(item);
		}

	}
}
