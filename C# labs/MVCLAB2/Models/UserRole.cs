namespace MVCLAB2.Models
{
    public class UserRole
    {

        public int userId { get; set; }

        public int roleId { get; set; }

        public User user { get; set; }

        public Role role { get; set; }
    }
}
