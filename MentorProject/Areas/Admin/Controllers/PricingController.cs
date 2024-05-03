using MentorProject.DAL;
using MentorProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MentorProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PricingController : Controller
    {
        private AppDbContext _context;

        public PricingController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public IActionResult Index()
        {
            List<Pricing> pricings = _context.Pricings.Include(x=>x.pricingFeatures).ToList();
            return View(pricings);
        }

        public IActionResult Create()
        {
            ViewBag.Features = _context.Features.ToList();
            return View();
        }

        [HttpPost]
		public IActionResult Create(Pricing pricing)
		{
			ViewBag.Features = _context.Features.ToList();
            if (!ModelState.IsValid)
            {
                return View(pricing);
            }

            foreach (var item in pricing.FeatureIds)
            {
                PricingFeature pricingFeature = new PricingFeature()
                {
                    FeatureId = item,
                    Pricing = pricing
                };
                //pricing.pricingFeatures.Add(pricingFeature);
                _context.PricingFeatures.Add(pricingFeature);
            }

            _context.Pricings.Add(pricing);
            _context.SaveChanges();

			return RedirectToAction("Index");
		}

		public IActionResult Edit(int id)
        {
			ViewBag.Features = _context.Features.Include(x=>x.pricingFeatures).ToList();

			Pricing? pricing = _context.Pricings.Include(x => x.pricingFeatures).FirstOrDefault(x => x.Id == id);
			return View(pricing);
        }

        [HttpPost]
        public IActionResult Edit(Pricing pricing)
        {
			ViewBag.Features = _context.Features.ToList();
			Pricing? existPricing = _context.Pricings.Include(x=>x.pricingFeatures).FirstOrDefault(x=>x.Id==pricing.Id);
            

			if (!ModelState.IsValid)
			{
				return View(pricing);
			}


			var featuresToDelete = existPricing.pricingFeatures.ToList();

			foreach (var selectedFeatureId in pricing.FeatureIds)
			{
				var existingPricingFeature = featuresToDelete.FirstOrDefault(pf => pf.FeatureId == selectedFeatureId);

				if (existingPricingFeature == null)
				{
					PricingFeature newPricingFeature = new PricingFeature()
					{
						FeatureId = selectedFeatureId,
						PricingId = pricing.Id
					};
					_context.PricingFeatures.Add(newPricingFeature);
				}
				else
				{
					featuresToDelete.Remove(existingPricingFeature);
				}
			}
			_context.PricingFeatures.RemoveRange(featuresToDelete);



			existPricing.Name = pricing.Name;
			existPricing.Price = pricing.Price;
			existPricing.IsAdvanced = pricing.IsAdvanced;
			existPricing.IsFeatured = pricing.IsFeatured;
            _context.SaveChanges();

			return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Pricing? pricing = _context.Pricings.Find(id);
            _context.Pricings.Remove(pricing);
            _context.SaveChanges();
            return Ok();
        }
    }
}
