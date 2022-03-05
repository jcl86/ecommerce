using Ecommerce.Application.Domain;
using Ecommerce.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Ecommerce.Core.Api
{
    public static class IdentityExtensions
    {
        public static IServiceCollection AddCustomAspnetIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<UserSettings>(configuration.GetSection("UserSettings"));
            services.AddScoped(x => x.GetRequiredService<IOptionsSnapshot<UserSettings>>().Value);

            string connectionString = configuration.GetConnectionString("SqlServer");

            services.AddDbContextPool<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>();

            services.AddScoped<UserManager<User>>();

            services.Configure<IdentityOptions>(options =>
            {
                options.ClaimsIdentity.UserIdClaimType = CustomClaims.UserId;
                options.ClaimsIdentity.UserNameClaimType = CustomClaims.Name;
                options.ClaimsIdentity.RoleClaimType = CustomClaims.Role;
                options.ClaimsIdentity.EmailClaimType = CustomClaims.Email;

                options.SignIn.RequireConfirmedAccount = true;
                options.SignIn.RequireConfirmedEmail = true;

                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(1);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });
            return services;
        }
    }
}