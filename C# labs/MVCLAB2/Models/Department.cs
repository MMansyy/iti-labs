using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCLAB2.Models
{
    public class Department
    {
        [Key , DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int deptID { get; set; }

        [Required, StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
        public string deptName { get; set; }

        [Range(1, 50, ErrorMessage = "Capacity must be a positive integer.")]
        public int? capacity { get; set; }

        

        public ICollection<Student> students { get; set; } = new HashSet<Student>();


    }
}
