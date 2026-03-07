using System.Collections.Generic;

namespace MVCLAB2.Models
{
    public class User
    {
        public int id { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public ICollection<UserRole> userRoles { get; set; } = new HashSet<UserRole>();

    }
}
