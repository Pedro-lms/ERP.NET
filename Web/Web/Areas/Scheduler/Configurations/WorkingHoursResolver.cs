using AutoMapper;
using Pedro.Scheduler.Core.Entities.ValueObjects;
using Pedro.Web.Configurations;

namespace Pedro.Web.Areas.Scheduler.Configurations
{
    public class WorkingHoursResolver<TSource, TDestination> : IValueResolver<TSource, TDestination, WorkingHours>
    {
        public WorkingHours Resolve(TSource source, TDestination destination, WorkingHours destMember, ResolutionContext context)
        {
            return ProperyResolverFactory.Resolve<TSource, TDestination, WorkingHours>(source, destination, "WorkingHours") as WorkingHours;
        }
    }
}
