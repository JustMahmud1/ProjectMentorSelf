namespace MentorProject.Models
{
    public class SocialMediaAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }
    }
}
