using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
 
namespace CustomizingIdentity.Models
{
    public class Role : IdentityRole<long, UserRole, IdentityRoleClaim<long>>
    {
        public Role()
        {
        }

        public Role(string name)
        {
            Name = name;
        }
    }
}
