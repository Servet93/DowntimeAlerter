using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebUI.Entities;

namespace WebUI.Infrastructure.Configurations
{
    public class EmailAdressConfiguration : IEntityTypeConfiguration<EmailAdress>
    {
        public void Configure(EntityTypeBuilder<EmailAdress> builder)
        {
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.ApplicationId).IsRequired();
            builder.HasOne(a => a.Application).WithMany(a => a.EmailAdresses).HasForeignKey(a => a.ApplicationId);
        }
    }
}
