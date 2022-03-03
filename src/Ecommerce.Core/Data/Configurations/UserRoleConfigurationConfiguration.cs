using Ecommerce.Application.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data
{
    public class UserRoleConfigurationConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
                var index = builder.HasKey(userRole => new { userRole.UserId, userRole.RoleId }).Metadata;
                builder.Metadata.RemoveKey(index.Properties);

                builder.HasKey(a => new { a.UserId, a.RoleId, a.CompanyId });

                builder.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                builder.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();

                builder.HasOne(u => u.Company)
                    .WithMany(c => c.UserRoles)
                    .HasForeignKey(u => u.CompanyId)
                    .OnDelete(DeleteBehavior.Cascade);
   
        }
    }
}
