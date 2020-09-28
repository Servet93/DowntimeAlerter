using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebUI.Entities;

namespace WebUI.Infrastructure.Configurations
{
    public class ApplicationFailRequestConfiguration : IEntityTypeConfiguration<ApplicationFailRequest>
    {
        public void Configure(EntityTypeBuilder<ApplicationFailRequest> builder)
        {
            builder.Property(p => p.DateTime).IsRequired();

            builder.HasOne(a => a.Application).WithMany(s => s.FailRequests).HasForeignKey(s => s.ApplicationId);
        }
    }
}
