using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MentorProject.Models
{
    public class AppUser:IdentityUser
    {
        [MaxLength(30)]
        [MinLength(5)]
        public string FullName { get; set; }
    }
}
