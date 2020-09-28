using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebUI.Entities;

namespace WebUI.Infrastructure.Configurations
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.Property(p => p.ApplicationId).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Url).IsRequired().HasMaxLength(250);
            builder.Property(p => p.RequestIntervalAtMinute).IsRequired();
            builder.Property(p => p.IsRun).HasDefaultValue(false);

            builder.HasMany(a => a.FailRequests).WithOne(s => s.Application).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(a => a.EmailAdresses).WithOne(s => s.Application).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(a => a.StatisticDaily).WithOne(s => s.Application).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(a => a.User).WithMany(a => a.Applications).HasForeignKey(a => a.UserId);
        }
    }
}
