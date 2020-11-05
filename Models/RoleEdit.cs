using System.Collections.Generic;
using Application.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace Application.Models
{
    public class RoleEdit
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<ApplicationUser> Members { get; set; }
        public IEnumerable<ApplicationUser> NonMembers { get; set; }
    }
}
