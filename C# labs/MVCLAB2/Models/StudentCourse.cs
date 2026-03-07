using System.ComponentModel.DataAnnotations;

namespace MVCLAB2.Models
{
    public class StudentCourse
    {
        public int studentId { get; set; }
        public int courseId { get; set; }

        [Range(0, 100, ErrorMessage = "Degree must be between 0 and 100.")]
        public double degree { get; set; } = 0;

        public Student student { get; set; }

        public Course course { get; set; }

    }
}
