using AutoMapper;
using Pedro.Scheduler.Core.Entities;
using Pedro.Web.Areas.Scheduler.Models.HomeViewModels;
using Pedro.Web.Areas.Scheduler.Models.PayrollViewModels;
using Pedro.Web.Areas.Scheduler.Models.SharedViewModels;

namespace Pedro.Web.Areas.Scheduler.Configurations
{
    public class AutoMapperSchedulerProfileConfiguration : Profile
    {
        public AutoMapperSchedulerProfileConfiguration()
        {
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<Employee, EmployeeConciseViewModel>();
            CreateMap<Project, ProjectViewModel>();
            CreateMap<Schedule, ScheduleViewModel>()
                .ForMember(x => x.ProjectOptions, opt => opt.Ignore())
                .ForMember(x => x.ScheduleOptions, opt => opt.Ignore())
                .ForMember(x => x.ScheduleOptionName, opt => opt.Ignore());
            CreateMap<Paycheck, PaycheckViewModel>()
                .ForMember(x => x.WorkingHours, opt => opt.ResolveUsing<WorkingHoursResolver<Paycheck, PaycheckViewModel>>())
                .ForMember(x => x.Period, opt => opt.ResolveUsing<PeriodResolver<Paycheck, PaycheckViewModel>>())
                .ForMember(x => x.DaysOff, opt => opt.ResolveUsing<DaysOffResolver<Paycheck, PaycheckViewModel>>());
        }
    }
}
