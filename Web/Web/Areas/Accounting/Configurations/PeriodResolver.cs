using AutoMapper;
using Accounting.Core.Entities.ValueObjects;
using Pedro.Web.Configurations;

namespace Pedro.Web.Areas.Accounting.Configurations
{
    public class PeriodResolver<TSource, TDestination> : IValueResolver<TSource, TDestination, Period>
    {
        public Period Resolve(TSource source, TDestination destination, Period destMember, ResolutionContext context)
        {
            return ProperyResolverFactory.Resolve<TSource, TDestination, Period>(source, destination, "Period") as Period;
        }
    }
}
