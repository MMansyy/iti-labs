using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCLAB2.Models
{
    public class Course
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int courseId { get; set; }

        [Required, StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
        public string name { get; set; }

        [Range(1, 50, ErrorMessage = "Capacity must be a positive integer.")]
        public int capacity { get; set; }

        [ForeignKey("department")]
        public int deptID { get; set; }

        [ValidateNever]
        public Department department { get; set; }
       
        public ICollection<StudentCourse> studentCourses { get; set; } = new HashSet<StudentCourse>();


    }
}
