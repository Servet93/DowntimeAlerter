using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebUI.Entities;
using WebUI.Models;

namespace WebUI.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Application> Applications { get; set; }
        public DbSet<ApplicationStatisticDaily> ApplicationStatisticDailys { get; set; }
        public DbSet<EmailAdress> EmailAdresses { get; set; }
        public DbSet<ApplicationFailRequest> ApplicationFailRequests { get; set; }
        public DbSet<NLogRecord> Logs { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");

            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

            #region Seed
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1",
                    Name = "Administrator",
                    NormalizedName = "Administrator"
                },
                new IdentityRole
                {   
                    Id = "2",
                    Name = "NormalUser",
                    NormalizedName = "NormalUser"
                }
            );

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "1",
                    UserName = "InvictiSecurityCorp",
                    Email = "invicti@security.com",
                    NormalizedEmail = "INVITI@SECURITY.COM",
                    PasswordHash = hasher.HashPassword(null, ".Ii123456"),
                },
                new ApplicationUser
                {
                    Id = "2",
                    UserName = "ServetSeker",
                    Email = "servetseker@security.com",
                    NormalizedEmail = "SERVETSEKER@SECURITY.COM",
                    PasswordHash = hasher.HashPassword(null, ".Ss123456"),
                },
                new ApplicationUser
                {
                    Id = "3",
                    UserName = "SerkanSeker",
                    Email = "serkanseker@security.com",
                    NormalizedEmail = "SERKANSEKER@SECURITY.COM",
                    PasswordHash = hasher.HashPassword(null, ".Ss654321"),
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "1",
                    RoleId = "1",
                },
                new IdentityUserRole<string>
                {
                    UserId = "2",
                    RoleId = "2",
                },
                new IdentityUserRole<string>
                {
                    UserId = "3",
                    RoleId = "2",
                }
            );

            builder.Entity<Application>().HasData(
                new Application
                {
                    ApplicationId=2,
                    Name = "Google",
                    Url = "https://www.google.com.tr",
                    RequestIntervalAtMinute = 20,
                    UserId = "2"
                },
                new Application
                {
                    ApplicationId = 3,
                    Name = "Samsung",
                    Url = "https://www.samsung.com/tr/",
                    RequestIntervalAtMinute = 10,
                    UserId = "2"
                },
                new Application
                {
                    ApplicationId = 4,
                    Name = "Xiaomi",
                    Url = "https://www.mi.com/tr/",
                    RequestIntervalAtMinute = 5,
                    UserId = "2"
                },
                new Application
                {
                    ApplicationId = 5,
                    Name = "General Mobile",
                    Url = "https://www.generalmobile.com/tr",
                    RequestIntervalAtMinute = 5,
                    UserId = "2"
                },
                new Application
                {
                    ApplicationId = 6,
                    Name = "Oppo",
                    Url = "https://www.oppo.com/tr/smartphones/?utm_source=google&utm_medium=search&utm_campaign=cn_alwayson&utm_content=ak%C4%B1ll%C4%B1%20telefonlar&gclid=Cj0KCQjwzbv7BRDIARIsAM-A6-0hkFPTs743FUnXof9wRSt4fgPlzfWzBmlJHJTc6bUycU0UjtGgOgkaAugfEALw_wcB",
                    RequestIntervalAtMinute = 5,
                    UserId = "2"
                },
                new Application
                {
                    ApplicationId = 7,
                    Name = "Vestel",
                    Url = "https://www.vestel.com.tr/?gclid=Cj0KCQjwzbv7BRDIARIsAM-A6-39gET4hChHg3TxYsrxCV97bFozXj-tS1BLXDo2NqVOyDT7Nnq4wEwaAutKEALw_wcB&gclsrc=aw.ds",
                    RequestIntervalAtMinute = 5,
                    UserId = "2"
                },
                new Application
                {
                    ApplicationId = 8,
                    Name = "Huawei",
                    RequestIntervalAtMinute = 10,
                    Url = "https://e.huawei.com/tr/huaweiconnect2020?utm_source=google&utm_medium=cpc&utm_campaign=01MHQHQ2052ZZL&utm_content=General&utm_term=Huawei&gclid=Cj0KCQjwzbv7BRDIARIsAM-A6-38oXMToS-y814N23FBg35Scr2JUmsbgBsdqYpZaNSVGkU-vO7scbkaArBAEALw_wcB",
                    UserId = "2"
                },
                new Application
                {
                    ApplicationId = 9,
                    Name = "Google 2",
                    Url = "https://www.google.com.tr",
                    RequestIntervalAtMinute = 20,
                    UserId = "3"
                },
                new Application
                {
                    ApplicationId = 10,
                    Name = "Samsung 2",
                    Url = "https://www.samsung.com/tr/",
                    RequestIntervalAtMinute = 10,
                    UserId = "3"
                },
                new Application
                {
                    ApplicationId = 11,
                    Name = "Xiaomi 2",
                    Url = "https://www.mi.com/tr/",
                    RequestIntervalAtMinute = 5,
                    UserId = "3"
                },
                new Application
                {
                    ApplicationId = 12,
                    Name = "General Mobile 2",
                    Url = "https://www.generalmobile.com/tr",
                    RequestIntervalAtMinute = 5,
                    UserId = "3"
                },
                new Application
                {
                    ApplicationId = 13,
                    Name = "Oppo 2",
                    Url = "https://www.oppo.com/tr/smartphones/?utm_source=google&utm_medium=search&utm_campaign=cn_alwayson&utm_content=ak%C4%B1ll%C4%B1%20telefonlar&gclid=Cj0KCQjwzbv7BRDIARIsAM-A6-0hkFPTs743FUnXof9wRSt4fgPlzfWzBmlJHJTc6bUycU0UjtGgOgkaAugfEALw_wcB",
                    RequestIntervalAtMinute = 5,
                    UserId = "3"
                },
                new Application
                {
                    ApplicationId = 14,
                    Name = "Vestel 2",
                    Url = "https://www.vestel.com.tr/?gclid=Cj0KCQjwzbv7BRDIARIsAM-A6-39gET4hChHg3TxYsrxCV97bFozXj-tS1BLXDo2NqVOyDT7Nnq4wEwaAutKEALw_wcB&gclsrc=aw.ds",
                    RequestIntervalAtMinute = 5,
                    UserId = "3"
                },
                new Application
                {
                    ApplicationId = 15,
                    Name = "Huawei 2",
                    RequestIntervalAtMinute = 10,
                    Url = "https://e.huawei.com/tr/huaweiconnect2020?utm_source=google&utm_medium=cpc&utm_campaign=01MHQHQ2052ZZL&utm_content=General&utm_term=Huawei&gclid=Cj0KCQjwzbv7BRDIARIsAM-A6-38oXMToS-y814N23FBg35Scr2JUmsbgBsdqYpZaNSVGkU-vO7scbkaArBAEALw_wcB",
                    UserId = "3"
                }
            );
            #endregion
        }
    }
}
