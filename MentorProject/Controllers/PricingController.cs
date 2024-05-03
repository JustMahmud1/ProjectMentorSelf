using MentorProject.DAL;
using MentorProject.VMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MentorProject.Controllers
{
	public class PricingController : Controller
	{
		private readonly AppDbContext _context;

		public PricingController(AppDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			PricingVM pricingVM = new PricingVM()
			{
				Pricings = _context.Pricings.Include(x => x.pricingFeatures).ToList(),
				Features = _context.Features.ToList(),
			};
			return View(pricingVM);
		}
	}
}
