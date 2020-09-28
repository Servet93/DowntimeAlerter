using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;
using Hangfire;
using Hangfire.Dashboard;
using WebUI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using WebUI.Entities;
using WebUI.Interfaces;
using WebUI.Business;
using WebUI.Models;
using WebUI.Infrastructure.Services;
using Microsoft.AspNetCore.Diagnostics;
using NLog;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("InvictiHealtMonitoringConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;

                // Default Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // Default SignIn settings.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

                // Default User settings.
                options.User.AllowedUserNameCharacters =
                        "abcdefghijklmnopqrstuvwxyz0123456789-._@";
                options.User.RequireUniqueEmail = true;
            });

            services.AddHangfire(config => config.UseSqlServerStorage(Configuration.GetConnectionString("InvictiBackgroundJobsConnection")));

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddScoped<HttpClient>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<EmailSender>();
            services.AddScoped<SmsSender>();
            services.AddScoped<INotificationSystem, NotificationSystem>();
            services.AddScoped<IBackgroundJob, InvictiBackgroundJob>();

            services.AddAntiforgery(options =>
            {
                options.Cookie.Name = "X-CSRF-TOKEN-INVICTI";
                options.FormFieldName = "CSRF-TOKEN-INVICTI-FORM";
                options.HeaderName = "CSRF-TOKEN-INVICTI";
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(c =>
                    {
                        c.ExpireTimeSpan = TimeSpan.FromMinutes(1);
                        c.LoginPath = "/Account";
                        c.LogoutPath = "/Account";
                        //Kaynak olduðu anlaþýlmasýn diye yanlýþ yönlendirme yapýlabilir.Anasayfaya yönlendiriyorum.
                        c.AccessDeniedPath = "/Home/Index";
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            LogManager.Configuration.Variables["ConnectionStrings"] = Configuration.GetConnectionString("InvictiHealtMonitoringConnection");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHangfireDashboard();
            app.UseHangfireServer();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            var notificationBackgroundJob = new InvictiBackgroundJob(app.ApplicationServices);
            RecurringJob.AddOrUpdate(() => notificationBackgroundJob.Run(), Cron.MinuteInterval(5));
        }
    }
}
