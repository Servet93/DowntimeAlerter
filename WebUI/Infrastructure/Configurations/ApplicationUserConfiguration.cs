using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebUI.Entities;
using WebUI.Models;

namespace WebUI.Infrastructure.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("Users");
            builder.HasMany(au => au.Applications).WithOne(a => a.User).HasForeignKey(a => a.UserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
