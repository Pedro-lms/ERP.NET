using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Accounting.Data;
using Pedro.Companies.Data;
using Pedro.Projects.Core.Entities;
using Pedro.Scheduler.Data;
using Pedro.Web.Events.Interfaces;

namespace Pedro.Web.Events.Handlers
{
    public class ProjectCteatedHandler : Handler
    {
        public ProjectCteatedHandler(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        public async override Task Handle(IDomainEvent args)
        {
            var eventArgs = args as ProjectCreated;
            if (eventArgs == null)
            {
                throw new InvalidCastException();
            }

            var accDbContext = this.ServiceProvider.GetService<AccountingDbContext>();
            var schedulerDbContext = this.ServiceProvider.GetService<SchedulerDbContext>();
            var companyDbContext = this.ServiceProvider.GetService<CompanyDbContext>();

            Mapper.Initialize(cfg =>
            {
                // Companies Maps
                cfg.CreateMap<Project, Companies.Core.Entities.Project>()
                    .ForMember(x => x.Contract, opt => opt.Ignore())
                    .ForMember(x => x.Customer, opt => opt.Ignore())
                    .ForSourceMember(x => x.Customer, opt => opt.Ignore())
                    .ForSourceMember(x => x.Manager, opt => opt.Ignore());

                // Accounting Maps
                cfg.CreateMap<Project, Accounting.Core.Entities.Project>()
                    .ForMember(x => x.Bills, opt => opt.Ignore())
                    .ForMember(x => x.Customer, opt => opt.Ignore())
                    .ForSourceMember(x => x.Customer, opt => opt.Ignore())
                    .ForSourceMember(x => x.Manager, opt => opt.Ignore());

                // Scheduler Maps
                cfg.CreateMap<Project, Scheduler.Core.Entities.Project>()
                    .ForSourceMember(x => x.Customer, opt => opt.Ignore())
                    .ForSourceMember(x => x.Manager, opt => opt.Ignore());
            });

            if (eventArgs.Projects != null)
            {
                var companyProjects = Mapper.Map<IEnumerable<Project>, IEnumerable<Companies.Core.Entities.Project>>(eventArgs.Projects);
                var accProjects = Mapper.Map<IEnumerable<Project>, IEnumerable<Accounting.Core.Entities.Project>>(eventArgs.Projects);
                var schedulerProjects = Mapper.Map<IEnumerable<Project>, IEnumerable<Scheduler.Core.Entities.Project>>(eventArgs.Projects);

                await companyDbContext.Set<Companies.Core.Entities.Project>().AddRangeAsync(companyProjects);
                await accDbContext.Set<Accounting.Core.Entities.Project>().AddRangeAsync(accProjects);
                await schedulerDbContext.Set<Scheduler.Core.Entities.Project>().AddRangeAsync(schedulerProjects);
                foreach (var project in schedulerProjects)
                {
                    project.SetShortName();
                }
            }

            if (eventArgs.Project != null)
            {
                var companyProject = Mapper.Map<Project, Companies.Core.Entities.Project>(eventArgs.Project);
                var accProject = Mapper.Map<Project, Accounting.Core.Entities.Project>(eventArgs.Project);
                var schedulerProject = Mapper.Map<Project, Scheduler.Core.Entities.Project>(eventArgs.Project);
                schedulerProject.SetShortName();

                await companyDbContext.Set<Companies.Core.Entities.Project>().AddAsync(companyProject);
                await accDbContext.Set<Accounting.Core.Entities.Project>().AddAsync(accProject);
                await schedulerDbContext.Set<Scheduler.Core.Entities.Project>().AddAsync(schedulerProject);
            }

            await accDbContext.SaveChangesAsync();
            await schedulerDbContext.SaveChangesAsync();
            await companyDbContext.SaveChangesAsync();
        }
    }
}
