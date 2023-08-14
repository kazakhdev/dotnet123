using System.Collections.Generic;

namespace FS.Todo.Api.Models
{
    public class AdminModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int RolesId { get; set; }
        public IEnumerable<Role> Roles { get; set; } // Assuming you have a Role model
    }
}
