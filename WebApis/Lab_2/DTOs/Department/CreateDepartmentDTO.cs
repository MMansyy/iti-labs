using System.ComponentModel.DataAnnotations;

namespace Lab_2.DTOs.Department
{
    public class CreateDepartmentDTO
    {
        [Required]
        public int DeptId { get; set; }

        [Required]
        [StringLength(50)]
        public string DeptName { get; set; }
    }
}
