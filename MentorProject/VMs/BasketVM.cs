namespace MentorProject.VMs
{
	public class BasketVM
	{
        public List<BasketItemVM> Items { get; set; } = new List<BasketItemVM>();
        public double TotalBasketPrice { get; set; }
    }
}
