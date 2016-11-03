using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
 

namespace CustomizingIdentity.Services
{
    public class SimpleSignInManager<TUser> : SignInManager<TUser> where TUser : class
    {
       
        private readonly IHttpContextAccessor _contextAccessor;
        private HttpContext _context;

        public SimpleSignInManager(UserManager<TUser> userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<TUser> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<TUser>> logger
         )
        : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger)
        {
            _contextAccessor = contextAccessor;
 

          
        }

        internal HttpContext Context
        {
            get
            {
                var context = _context ?? _contextAccessor?.HttpContext;
                if (context == null)
                {
                    throw new InvalidOperationException("HttpContext must not be null.");
                }
                return context;
            }
            set
            {
                _context = value;
            }
        }

        public override async Task SignInAsync(TUser user, bool isPersistent, string authenticationMethod = null)
        {
            var userId = await UserManager.GetUserIdAsync(user);
           
            await base.SignInAsync(user, isPersistent, authenticationMethod);
        }
    }


}
