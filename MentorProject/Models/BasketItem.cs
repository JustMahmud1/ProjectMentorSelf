namespace MentorProject.Models
{
	public class BasketItem
	{
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int AppUserId { get; set; }
        public int Count { get; set; }
        public Course Course { get; set; }
        public AppUser AppUser { get; set; }
    }
}
