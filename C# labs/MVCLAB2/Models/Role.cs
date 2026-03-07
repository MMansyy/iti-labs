using System.Collections.Generic;

namespace MVCLAB2.Models
{
    public class Role
    {
        public int id { get; set; }

        public string name { get; set; }

        public ICollection<UserRole> userRoles { get; set; } = new HashSet<UserRole>();
    }
}
