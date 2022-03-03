using System.Security.Claims;

namespace Ecommerce.Api
{
    public static class ClaimsPrincipalExtensions
    {
        public static bool HasRoleInCompany(this ClaimsPrincipal principal, int companyId, string roleName)
        {
            string value = principal.FindFirst(CustomClaims.RoleInCompany)?.Value;

            if (value is null)
            {
                return false;
            }

            var splitted = value.Split(":");
            if (splitted.Count() != 2) return false;
            if (!int.TryParse(splitted[0], out int claimSchoolId))
            {
                return false;
            }

            return claimSchoolId == companyId && splitted[0] == roleName;
        }

        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.Email);
        }

        public static string GetUserId(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static string GetUserName(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.Name);
        }

        public static bool IsCurrentUser(this ClaimsPrincipal principal, Guid idUser)
        {
            var currentUserId = GetUserId(principal);

            return string.Equals(currentUserId, idUser.ToString(), StringComparison.OrdinalIgnoreCase);
        }
    }
}