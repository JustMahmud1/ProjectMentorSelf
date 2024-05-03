using System.ComponentModel.DataAnnotations.Schema;

namespace MentorProject.Models
{
	public class Pricing
	{
		public int Id { get; set; }
		public string Name { get; set; }
		[Column(TypeName = "money")]
		public decimal Price { get; set; }
		public string ButtonText { get; set; }
		public string ButtonLink { get; set; }
		public bool IsFeatured { get; set; }
		public bool IsAdvanced { get; set; }
		public List<PricingFeature>? pricingFeatures { get; set; }
		[NotMapped]
        public List<int>? FeatureIds { get; set; } = new List<int>();
    }
}
