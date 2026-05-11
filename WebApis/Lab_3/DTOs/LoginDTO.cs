using System.ComponentModel.DataAnnotations;

namespace Lab_3.DTOs
{
    public class LoginDTO
    {

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
