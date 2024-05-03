namespace MentorProject.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Branch { get; set; }
        public string ImgUrl { get; set; }
        public List<Course> Courses { get; set; }
        public List<SocialMediaAccount> Accounts { get; set; }
    }
}
