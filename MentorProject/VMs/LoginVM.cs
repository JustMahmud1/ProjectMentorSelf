using System.ComponentModel.DataAnnotations;

namespace MentorProject.VMs
{
    public class LoginVM
    {
        [MaxLength(35)]
        [MinLength(5)]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(8)]
        [Required]
        [MaxLength(35)]
        public string Password { get; set; }
    }
}
