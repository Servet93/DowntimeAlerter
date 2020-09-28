using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebUI.Entities;

namespace WebUI.Infrastructure.Configurations
{
    public class ApplicationStatisticDailyConfiguration : IEntityTypeConfiguration<ApplicationStatisticDaily>
    {
        public void Configure(EntityTypeBuilder<ApplicationStatisticDaily> builder)
        {
            builder.Property(p => p.DateTime).IsRequired();
            builder.Property(p => p.TotalRequest).HasDefaultValue(0);
            builder.Property(p => p.SuccessRequest).HasDefaultValue(0);
            builder.Property(p => p.FailRequest).HasDefaultValue(0);

            builder.HasOne(a => a.Application).WithMany(s => s.StatisticDaily).HasForeignKey(s => s.ApplicationId);
        }
    }
}
