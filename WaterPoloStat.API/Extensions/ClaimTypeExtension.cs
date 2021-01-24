using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WaterPoloStat.API.Extensions
{
    public static class ClaimTypeExtension
    {
        public const string LicenzaId = "LicenzaId";
        public const string UserId = "UserId";
        public static string GetLicenzaId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentNullException(nameof(principal));
            }
            var claim = principal.FindFirst(LicenzaId);
            return claim != null ? claim.Value : null;
        }
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentNullException(nameof(principal));
            }
            var claim = principal.FindFirst(UserId);
            return claim != null ? claim.Value : null;
        }

    }
}
