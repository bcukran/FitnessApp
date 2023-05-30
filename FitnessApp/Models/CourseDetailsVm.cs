using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace FitnessApp.Models
{
    public class CourseDetailsVm
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Ders İsmi")]
        public string Name { get; set; } = null!;

        [DisplayName("Ders Açıklama")]
        public string? Description { get; set; }

        [DisplayName("Süre")]
        public byte Duration { get; set; }

        public int? EnrollId {  get; set; }
    }
}
