namespace FitnessApp.Models
{
    public class AddCourseVm
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public byte Duration { get; set; }
    }
}
