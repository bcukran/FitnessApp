namespace FitnessApp.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public byte Duration { get; set; }

        public virtual ICollection<Enroll> Enrolls { get; } = new List<Enroll>();
    }
}
