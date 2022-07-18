using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Core.Extensions
{
    //9
    
    public static class ClaimsPrincipalExtensions
    {
        //Claims Pricipal
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            //? --> null 
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }

        //ClaimRoles
        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}