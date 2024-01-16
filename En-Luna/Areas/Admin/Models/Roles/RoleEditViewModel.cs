using En_Luna.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace En_Luna.Areas.Admin.Models
{
    public class RoleEditViewModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<User> Members { get; set; }
        public IEnumerable<User> NonMembers { get; set; }
    }
}
