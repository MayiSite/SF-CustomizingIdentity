using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
 
namespace CustomizingIdentity.Models
{
    public class ApplicationUser : IdentityUser<long, IdentityUserClaim<long>, UserRole, IdentityUserLogin<long>>
    {
        public ApplicationUser()
        {
            CreatedOn = DateTimeOffset.Now;
            UpdatedOn = DateTimeOffset.Now;
        }

        public Guid UserGuid { get; set; }

        public string FullName { get; set; }

        public bool IsDeleted { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset UpdatedOn { get; set; }

   

        public long? CurrentShippingAddressId { get; set; }
    }
}
