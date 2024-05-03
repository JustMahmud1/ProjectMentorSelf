namespace MentorProject.Models
{
	public class Feature
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<PricingFeature> pricingFeatures { get; set; }
	}
}
