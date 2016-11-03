using System.Security.Claims;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CustomizingIdentity.Data;

namespace CustomizingIdentity.Models
{
    public class SimplRoleStore: RoleStore<Role, ApplicationFDbContext, long, UserRole, IdentityRoleClaim<long>>
    {
        public SimplRoleStore(ApplicationFDbContext context) : base(context)
        {
        }

        protected override IdentityRoleClaim<long> CreateRoleClaim(Role role, Claim claim)
        {
            return new IdentityRoleClaim<long> { RoleId = role.Id, ClaimType = claim.Type, ClaimValue = claim.Value };
        }
    }
}
