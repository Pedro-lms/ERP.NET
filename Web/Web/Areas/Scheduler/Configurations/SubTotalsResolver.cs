using AutoMapper;
using Accounting.Core.Entities.ValueObjects;
using Pedro.Web.Configurations;

namespace Pedro.Web.Areas.Scheduler.Configurations
{
    public class SubTotalsResolver<TSource, TDestination> : IValueResolver<TSource, TDestination, SubTotals>
    {
        public SubTotals Resolve(TSource source, TDestination destination, SubTotals destMember, ResolutionContext context)
        {
            return ProperyResolverFactory.Resolve<TSource, TDestination, SubTotals>(source, destination, "SubTotals") as SubTotals;
        }
    }
}
