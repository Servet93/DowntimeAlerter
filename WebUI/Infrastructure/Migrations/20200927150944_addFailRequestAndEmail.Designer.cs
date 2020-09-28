﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebUI.Infrastructure.Persistence;

namespace WebUI.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200927150944_addFailRequestAndEmail")]
    partial class addFailRequestAndEmail
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            ConcurrencyStamp = "4774cf9a-4759-46ce-aabd-1477f8c08415",
                            Name = "Administrator",
                            NormalizedName = "Administrator"
                        },
                        new
                        {
                            Id = "2",
                            ConcurrencyStamp = "cdd7a1c3-c0c0-4d46-8dbc-2fe5bf0151fd",
                            Name = "NormalUser",
                            NormalizedName = "NormalUser"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "1",
                            RoleId = "1"
                        },
                        new
                        {
                            UserId = "2",
                            RoleId = "2"
                        },
                        new
                        {
                            UserId = "3",
                            RoleId = "2"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("WebUI.Entities.Application", b =>
                {
                    b.Property<int>("ApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsRun")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("JobId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("RequestIntervalAtMinute")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ApplicationId");

                    b.HasIndex("UserId");

                    b.ToTable("Applications");

                    b.HasData(
                        new
                        {
                            ApplicationId = 2,
                            IsRun = false,
                            Name = "Google",
                            RequestIntervalAtMinute = 20,
                            Url = "https://www.google.com.tr",
                            UserId = "2"
                        },
                        new
                        {
                            ApplicationId = 3,
                            IsRun = false,
                            Name = "Samsung",
                            RequestIntervalAtMinute = 10,
                            Url = "https://www.samsung.com/tr/",
                            UserId = "2"
                        },
                        new
                        {
                            ApplicationId = 4,
                            IsRun = false,
                            Name = "Xiaomi",
                            RequestIntervalAtMinute = 5,
                            Url = "https://www.mi.com/tr/",
                            UserId = "2"
                        },
                        new
                        {
                            ApplicationId = 5,
                            IsRun = false,
                            Name = "General Mobile",
                            RequestIntervalAtMinute = 5,
                            Url = "https://www.generalmobile.com/tr",
                            UserId = "2"
                        },
                        new
                        {
                            ApplicationId = 6,
                            IsRun = false,
                            Name = "Oppo",
                            RequestIntervalAtMinute = 5,
                            Url = "https://www.oppo.com/tr/smartphones/?utm_source=google&utm_medium=search&utm_campaign=cn_alwayson&utm_content=ak%C4%B1ll%C4%B1%20telefonlar&gclid=Cj0KCQjwzbv7BRDIARIsAM-A6-0hkFPTs743FUnXof9wRSt4fgPlzfWzBmlJHJTc6bUycU0UjtGgOgkaAugfEALw_wcB",
                            UserId = "2"
                        },
                        new
                        {
                            ApplicationId = 7,
                            IsRun = false,
                            Name = "Vestel",
                            RequestIntervalAtMinute = 5,
                            Url = "https://www.vestel.com.tr/?gclid=Cj0KCQjwzbv7BRDIARIsAM-A6-39gET4hChHg3TxYsrxCV97bFozXj-tS1BLXDo2NqVOyDT7Nnq4wEwaAutKEALw_wcB&gclsrc=aw.ds",
                            UserId = "2"
                        },
                        new
                        {
                            ApplicationId = 8,
                            IsRun = false,
                            Name = "Huawei",
                            RequestIntervalAtMinute = 10,
                            Url = "https://e.huawei.com/tr/huaweiconnect2020?utm_source=google&utm_medium=cpc&utm_campaign=01MHQHQ2052ZZL&utm_content=General&utm_term=Huawei&gclid=Cj0KCQjwzbv7BRDIARIsAM-A6-38oXMToS-y814N23FBg35Scr2JUmsbgBsdqYpZaNSVGkU-vO7scbkaArBAEALw_wcB",
                            UserId = "2"
                        },
                        new
                        {
                            ApplicationId = 9,
                            IsRun = false,
                            Name = "Google 2",
                            RequestIntervalAtMinute = 20,
                            Url = "https://www.google.com.tr",
                            UserId = "3"
                        },
                        new
                        {
                            ApplicationId = 10,
                            IsRun = false,
                            Name = "Samsung 2",
                            RequestIntervalAtMinute = 10,
                            Url = "https://www.samsung.com/tr/",
                            UserId = "3"
                        },
                        new
                        {
                            ApplicationId = 11,
                            IsRun = false,
                            Name = "Xiaomi 2",
                            RequestIntervalAtMinute = 5,
                            Url = "https://www.mi.com/tr/",
                            UserId = "3"
                        },
                        new
                        {
                            ApplicationId = 12,
                            IsRun = false,
                            Name = "General Mobile 2",
                            RequestIntervalAtMinute = 5,
                            Url = "https://www.generalmobile.com/tr",
                            UserId = "3"
                        },
                        new
                        {
                            ApplicationId = 13,
                            IsRun = false,
                            Name = "Oppo 2",
                            RequestIntervalAtMinute = 5,
                            Url = "https://www.oppo.com/tr/smartphones/?utm_source=google&utm_medium=search&utm_campaign=cn_alwayson&utm_content=ak%C4%B1ll%C4%B1%20telefonlar&gclid=Cj0KCQjwzbv7BRDIARIsAM-A6-0hkFPTs743FUnXof9wRSt4fgPlzfWzBmlJHJTc6bUycU0UjtGgOgkaAugfEALw_wcB",
                            UserId = "3"
                        },
                        new
                        {
                            ApplicationId = 14,
                            IsRun = false,
                            Name = "Vestel 2",
                            RequestIntervalAtMinute = 5,
                            Url = "https://www.vestel.com.tr/?gclid=Cj0KCQjwzbv7BRDIARIsAM-A6-39gET4hChHg3TxYsrxCV97bFozXj-tS1BLXDo2NqVOyDT7Nnq4wEwaAutKEALw_wcB&gclsrc=aw.ds",
                            UserId = "3"
                        },
                        new
                        {
                            ApplicationId = 15,
                            IsRun = false,
                            Name = "Huawei 2",
                            RequestIntervalAtMinute = 10,
                            Url = "https://e.huawei.com/tr/huaweiconnect2020?utm_source=google&utm_medium=cpc&utm_campaign=01MHQHQ2052ZZL&utm_content=General&utm_term=Huawei&gclid=Cj0KCQjwzbv7BRDIARIsAM-A6-38oXMToS-y814N23FBg35Scr2JUmsbgBsdqYpZaNSVGkU-vO7scbkaArBAEALw_wcB",
                            UserId = "3"
                        });
                });

            modelBuilder.Entity("WebUI.Entities.ApplicationFailRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.ToTable("ApplicationFailRequests");
                });

            modelBuilder.Entity("WebUI.Entities.ApplicationStatisticDaily", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("FailRequest")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("SuccessRequest")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("TotalRequest")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.ToTable("ApplicationStatisticDailys");
                });

            modelBuilder.Entity("WebUI.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "228a1f51-e682-40cf-9434-b2cf4314b5ed",
                            Email = "invicti@security.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEE1Z0Xq+jDMoLd6F7ot6OTyFiNK9XcYS4J14/oejZJznfg4f9ISW7T4qtbT/Rg1yJg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e00ec616-5e48-452e-922f-361d84868030",
                            TwoFactorEnabled = false,
                            UserName = "InvictiSecurityCorp"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f626f294-e0d7-48d9-98d8-1eb4264c534a",
                            Email = "servetseker@security.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAELkNSIM4zQFFdZOzF+q8mSvv4jZtqsVA+OGRPQ1QMp+58Ii8DZD9dliPUhiu8kFYpQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "afbf5758-0981-4c80-ba57-562e26f60950",
                            TwoFactorEnabled = false,
                            UserName = "ServetSeker"
                        },
                        new
                        {
                            Id = "3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "833d21c4-3520-44d1-838b-c7f9ad799dc1",
                            Email = "serkanseker@security.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAELTObeqk6go49uhP8V+qUtF/VX8kUNBP69aV8pBIc06Xsu/SpXcrtn+xa96Q+xGSwQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e5a65deb-9815-4e7c-8f49-cd9517bdf2da",
                            TwoFactorEnabled = false,
                            UserName = "SerkanSeker"
                        });
                });

            modelBuilder.Entity("WebUI.Entities.EmailAdress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.ToTable("EmailAdresses");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebUI.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebUI.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebUI.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebUI.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebUI.Entities.Application", b =>
                {
                    b.HasOne("WebUI.Entities.ApplicationUser", "User")
                        .WithMany("Applications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebUI.Entities.ApplicationFailRequest", b =>
                {
                    b.HasOne("WebUI.Entities.Application", "Application")
                        .WithMany("FailRequests")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebUI.Entities.ApplicationStatisticDaily", b =>
                {
                    b.HasOne("WebUI.Entities.Application", "Application")
                        .WithMany("StatisticDaily")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebUI.Entities.EmailAdress", b =>
                {
                    b.HasOne("WebUI.Entities.Application", "Application")
                        .WithMany("EmailAdresses")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
