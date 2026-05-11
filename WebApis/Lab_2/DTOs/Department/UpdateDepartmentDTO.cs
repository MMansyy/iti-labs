using System.ComponentModel.DataAnnotations;

namespace Lab_2.DTOs.Department
{
    public class UpdateDepartmentDTO
    {
        [StringLength(50)]
        public string? DeptName { get; set; }
    }
}
