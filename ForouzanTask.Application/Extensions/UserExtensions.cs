using ForouzanTask.Application.DTOs.User;
using ForouzanTask.DataLayer.Entities.Common;
using System.Security.Claims;

namespace ForouzanTask.Application.Extensions
{
    public static class UserExtensions
    {

        public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            var identifier = claimsPrincipal.Claims.SingleOrDefault(s =>
            s.Type == ClaimTypes.NameIdentifier);

            if (identifier == null) return Guid.Empty;

            return Guid.Parse(identifier.Value);
        }

        public static string DisplayName(this UserDto user)
        {
            if (!string.IsNullOrEmpty(user.FullName))
            {
                return user.FullName;
            }
            else if(user.UserName!=null) return user.UserName;
            return string.Empty;
        }

    }
}
