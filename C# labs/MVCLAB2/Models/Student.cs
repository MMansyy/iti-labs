using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCLAB2.Models
{
    public class Student
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required, StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
        public string name { get; set; }

        [Required, Range(5, 90, ErrorMessage = "Age must be between 5 and 90.")]
        public int age { get; set; }

        [ForeignKey(nameof(department))]
        public int deptId { get; set; }


        [ValidateNever]
        public virtual Department department { get; set; }




    }
}
