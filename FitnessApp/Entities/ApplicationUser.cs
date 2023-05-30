using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Entities
{
    public class ApplicationUser : IdentityUser
    {

        [StringLength(50)] 
        public string FirstName { get; set; } = string.Empty;

        [StringLength(50)] 
        public string LastName { get; set; } = string.Empty;

        public virtual ICollection<Enroll> Enrolls { get; } = new List<Enroll>();
    }
}
