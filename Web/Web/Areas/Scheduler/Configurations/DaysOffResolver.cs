using AutoMapper;
using Pedro.Scheduler.Core.Entities.ValueObjects;
using Pedro.Web.Configurations;

namespace Pedro.Web.Areas.Scheduler.Configurations
{
    public class DaysOffResolver<TSource, TDestination> : IValueResolver<TSource, TDestination, DaysOff>
    {
        public DaysOff Resolve(TSource source, TDestination destination, DaysOff destMember, ResolutionContext context)
        {
            return ProperyResolverFactory.Resolve<TSource, TDestination, DaysOff>(source, destination, "DaysOff") as DaysOff;
        }
    }
}
