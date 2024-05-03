using MentorProject.Attributes.ValidationAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MentorProject.Models
{
    public class Course
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [MinLength(5)]
        public string Name { get; set; }
		[MaxLength(200)]
		public string Description { get; set; }
		[MaxLength(15)]
		public string Category { get; set; }
        public double Price { get; set; }
        public string? ImageName { get; set; }
        public int TrainerId { get; set; }
        public Trainer? Trainer { get; set; }
        [NotMapped]
        [MaxSize(2*1024*1024)]
        [AllowedTypes("image/png","image/jpg", "image/jpeg")]
        public IFormFile ImageFile { get; set; }
    }
}
