using System.ComponentModel.DataAnnotations;

namespace Lab_2.DTOs.Student
{
    public class CreateStudentDTO
    {

        [Required]
        public int StudentId { get; set; }
        [Required]
        [StringLength(50)]
        public string StFname { get; set; }
        [Required]
        [StringLength(50)]
        public string StLname { get; set; }
        [Required]
        public int DeptId { get; set; }

        public string? StAddress { get; set; }

        public int StAge { get; set; }
        public int? SuperviorId { get; set; }

    }
}
