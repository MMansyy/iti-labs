using System.ComponentModel.DataAnnotations;

namespace MVCLAB2.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email is required")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required"), DataType(DataType.Password)]
        public string password { get; set; }
    }
}
