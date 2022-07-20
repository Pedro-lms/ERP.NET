using Microsoft.Extensions.DependencyInjection;

namespace Pedro.Web.Seed
{
    public interface IRolesSeder
    {
        void Seed(IServiceScopeFactory services);
    }
}
