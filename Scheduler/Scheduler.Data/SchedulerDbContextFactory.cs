using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Pedro.Scheduler.Data
{
    public class SchedulerDbContextFactory : IDbContextFactory<SchedulerDbContext>
    {
        public SchedulerDbContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<SchedulerDbContext>();
            builder.UseSqlServer("Server=.;Database=Pedro;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new SchedulerDbContext(builder.Options);
        }
    }
}
