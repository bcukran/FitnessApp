using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models
{
    public class EnrollerVm
    {
        [Display(Name = "Ad")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Soyad")]
        public string LastName { get; set; } = null!;

        [Display(Name = "E-posta")]
        public string Email { get; set; } = null!;
    }
}
