using System;
using System.Threading.Tasks;
using Pedro.Web.Events.Interfaces;

namespace Pedro.Web.Events.Handlers
{
    public abstract class Handler : IHandle<IDomainEvent>
    {
        public Handler(IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
        }

        public IServiceProvider ServiceProvider { get; set; }

        public abstract Task Handle(IDomainEvent args);
    }
}
