using Microsoft.Extensions.DependencyInjection;
using Pedro.Web.Events.Interfaces;

namespace Pedro.Web.Seed
{
    public interface IDatabaseSeeder
    {
        void Seed(IServiceScopeFactory services, IEventsFactory eventsFactory);
    }
}
