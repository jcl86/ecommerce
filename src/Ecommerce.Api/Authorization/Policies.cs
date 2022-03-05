using Ecommerce.Application.Domain;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.Core.Api
{
    public static partial class Policies
    {
        public const string IsSuperAdministrator = nameof(IsSuperAdministrator);

        public static void Configure(AuthorizationOptions options)
        {
            options.InvokeHandlersAfterFailure = true;

            options.AddPolicy(IsSuperAdministrator, policyBuilder =>
            {
                policyBuilder.RequireAuthenticatedUser();
                policyBuilder.RequireRole(RoleNames.SuperAdministrator);
            });
        }
    }
}