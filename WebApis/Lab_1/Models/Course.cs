using System.ComponentModel.DataAnnotations;

namespace Lab_1.Models
{
    public class Course
    {

        [Key]
        public int ID { get; set; }

        [Required, Length(minimumLength: 1, maximumLength: 50, ErrorMessage = "Course name is requird")]
        public string Crs_name { get; set; }

        [Length(minimumLength: 0, maximumLength: 150, ErrorMessage = "Maximum length is 150")]
        public string Crs_desc { get; set; } = string.Empty;

        [Required]
        public int Duration { get; set; }


    }
}
