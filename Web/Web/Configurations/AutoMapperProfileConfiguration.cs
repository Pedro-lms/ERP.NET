using AutoMapper;
using Pedro.Companies.Core.Entities;
using Pedro.Web.Models.SharedViewModels;

namespace Pedro.Web.Configurations
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            //CreateMap<Employee, Scheduler.Core.Entities.Employee>();
            //CreateMap<PayRateViewModel, Scheduler.Core.Entities.PayRate>();
            //CreateMap<Project, Scheduler.Core.Entities.Project>();
        }
    }
}
