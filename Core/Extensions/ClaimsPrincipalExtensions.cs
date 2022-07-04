using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Core.Extensions
{
    //9
    //Bir kişinin claim'leri aranırken .Net biraz uğraştırır.
    //Bundan dolayı kolay erişim sağlayabilmek için aşağıdaki kod satırlarının yazılması gerekmektedir.
    public static class ClaimsPrincipalExtensions
    {
        //ClaimsPricipal --> bir kişinin claimlerine erişmek için .Net' de olan class'tır. Aşağıda this keywrd' ü ile extend edilmiştir.
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            //? --> null olabilir.
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }

        //ClaimRoles --> direkt rolleri gönder
        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}