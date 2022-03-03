using Ecommerce.Application.Domain;
using Ecommerce.Sales.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Ecommerce.Data
{
    public class ApplicationDbContext : IdentityDbContext<User,
       Role,
       string,
       IdentityUserClaim<string>,
       UserRole,
       IdentityUserLogin<string>,
       IdentityRoleClaim<string>,
       IdentityUserToken<string>>
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {  }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
