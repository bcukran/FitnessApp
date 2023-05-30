using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Entities
{
    public class Enroll
    {
        public int Id { get; set; }
        public int CourseId { get; set; }

        [StringLength(450)]
        public string UserId { get; set; } = null!;

        public virtual Course Course { get; set; } = null!;

        public virtual ApplicationUser User { get; set; } = null!;
    }
}
