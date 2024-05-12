using MentorProject.Models;

namespace MentorProject.VMs
{
	public class BasketItemVM
	{
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public double TotalPrice { get; set; }
    }
}
