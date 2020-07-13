using EventManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EventManager.Helpers.AuthProvider
{
    /// <summary>
    /// Current user logged in
    /// </summary>
    public class CurrentUser
    {
        private ClaimsPrincipal user;

        public CurrentUser(ClaimsPrincipal user)
        {
            this.user = user;
        }

        public static CurrentUser GetCurrentUser(ClaimsPrincipal user)
        {
            return new CurrentUser(user);
        }

        //Check if the current user has the role passed as parameter
        public bool IsInRole(Role role)
        {
            return user.HasClaim(Constants.CLAIM_ROLE_ID, ((int)role).ToString());
        }

        public Guid UserId
        {
            get
            {
                return new Guid(this.user.FindFirst(Constants.CLAIM_USER_ID).Value);
            }
        }
    }
}
