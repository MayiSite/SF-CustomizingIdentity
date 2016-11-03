using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CustomizingIdentity.Models
{
    public class UserRole : IdentityUserRole<long>
    {
        public override long UserId { get; set; }

        public ApplicationUser User { get; set; }

        public override long RoleId { get; set; }

        public Role Role { get; set; }
    }
}
