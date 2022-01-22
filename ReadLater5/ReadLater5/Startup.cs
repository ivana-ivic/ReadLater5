using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReadLater5.Services;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadLater5
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
            services.AddDbContext<ReadLaterDataContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ReadLaterDataContext>();


            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<EmailSenderOptions>(Configuration.GetSection("EmailConfiguration"));

            //services.Configure<EmailConfiguration>(Configuration.GetSection("MailSettings"));

            //var emailConfig = Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            //services.AddSingleton(emailConfig);
            ////services.AddScoped<EmailService.IEmailSender, EmailService.EmailSender>();
            //services.AddTransient<EmailService.IEmailSender, EmailService.EmailSender>();
            //services.Configure<EmailConfiguration>(Configuration.GetSection("EmailConfiguration"));
            ////services.AddTransient<IEmailSender, EmailSender>();
            ////services.Configure<AuthMessageSenderOptions>(Configuration);

            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IBookmarkService, BookmarkService>();

            services.AddControllersWithViews();

            //services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
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
                endpoints.MapRazorPages();
            });
        }
    }
}
