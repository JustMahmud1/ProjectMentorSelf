using MentorProject.DAL;
using MentorProject.Models;
using MentorProject.VMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MentorProject.Controllers
{
	public class BasketController : Controller
	{
		private AppDbContext _context;

		public BasketController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			List<BasketCookieItemVM>? items = JsonConvert.DeserializeObject<List<BasketCookieItemVM>>(Request.Cookies["Courses"]);
			if(items == null)
			{
				return View();
			}
			BasketVM basketVM = new BasketVM();

			foreach (var item in items)
			{
				var course = _context.Courses.Include(x => x.Trainer).FirstOrDefault(x => x.Id == item.CourseId);
				if (course == null)
				{
					return BadRequest();
				}
				else
				{
					BasketItemVM basketItem = new BasketItemVM()
					{
						CourseId = course.Id,
						Name=course.Name,
						Image=course.ImageName,
						Price=course.Price,
						Count= item.Count,
						TotalPrice=course.Price * item.Count,
					};
					basketVM.TotalBasketPrice += basketItem.TotalPrice;
					basketVM.Items.Add(basketItem);
				}
			}


			return View(basketVM);
		}
	}
}
