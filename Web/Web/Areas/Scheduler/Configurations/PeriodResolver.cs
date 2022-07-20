using AutoMapper;
using Pedro.Scheduler.Core.Entities.ValueObjects;
using Pedro.Web.Configurations;

namespace Pedro.Web.Areas.Scheduler.Configurations
{
    public class PeriodResolver<TSource, TDestination> : IValueResolver<TSource, TDestination, Period>
    {
        public Period Resolve(TSource source, TDestination destination, Period destMember, ResolutionContext context)
        {
            return ProperyResolverFactory.Resolve<TSource, TDestination, Period>(source, destination, "Period") as Period;
        }
    }
}
