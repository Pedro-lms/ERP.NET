﻿using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Accounting.Data;
using Accounting.Data.DataAccess;
using Pedro.Companies.Core.Entities;
using Pedro.Companies.Data;
using Pedro.Companies.Data.DataAccess;
using Pedro.Projects.Data;
using Pedro.Projects.Data.DataAccess;
using Pedro.Scheduler.Data;
using Pedro.Scheduler.Data.DataAccess;
using Pedro.Web.Areas.Scheduler.Services;
using Pedro.Web.Events;
using Pedro.Web.Events.Interfaces;
using Pedro.Web.Seed;
using Pedro.Web.Services;

namespace Pedro.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services
                .AddDbContext<CompanyDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")))
                .AddDbContext<AccountingDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")))
                .AddDbContext<ProjectsDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")))
                .AddDbContext<SchedulerDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<CompanyDbContext>()
                .AddDefaultTokenProviders();
            
            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddTransient<AutoMapper.IConfigurationProvider, MapperConfiguration>();

            services.AddTransient<IScheduleSevice, ScheduleSevice>();
            services.AddTransient<IPayrollService, PayrollService>();
            services.AddTransient<Areas.Accounting.Services.IPayrollService, Areas.Accounting.Services.PayrollService>();

            services.AddScoped<IMapper>(sp =>
                new Mapper(new MapperConfiguration(cfg => cfg.AddProfiles(Assembly.GetEntryAssembly()))));
            services.AddScoped<IDatabaseSeeder>(sp => new DatabaseSeeder());
            services.AddScoped<IRolesSeder>(sp => new RolesSeeder());

            // Add application work dbContexts
            services.AddTransient<ICompanyWorkData, CompanyWorkData>();
            services.AddTransient<IAccountingWorkData, AccountingWorkData>();
            services.AddTransient<IProjectsWorkData, ProjectsWorkData>();
            services.AddTransient<ISchedulerWorkData, SchedulerWorkData>();

            // Add application events
            services.AddTransient<IEventsFactory, EventsFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                // Areas support
                routes.MapRoute(
                  name: "areaRoute",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}/{id?}");
            });

            // Create database if it doesn't exist and apply pending migrations.
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var accountingDb = scope.ServiceProvider.GetRequiredService<AccountingDbContext>();
                var companiesDb = scope.ServiceProvider.GetRequiredService<CompanyDbContext>();
                var projectsDb = scope.ServiceProvider.GetRequiredService<ProjectsDbContext>();
                var schedulerDb = scope.ServiceProvider.GetRequiredService<SchedulerDbContext>();

                accountingDb.Database.Migrate();
                companiesDb.Database.Migrate();
                projectsDb.Database.Migrate();
                schedulerDb.Database.Migrate(); 
            }
        }
    }
}
