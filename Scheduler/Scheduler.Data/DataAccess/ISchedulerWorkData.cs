using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pedro.Scheduler.Data.DataAccess.Repositories;
using Pedro.Scheduler.Core.Entities;

namespace Pedro.Scheduler.Data.DataAccess
{
    public interface ISchedulerWorkData
    {
        IRepository<Employee> Employees { get; }
        IRepository<Schedule> Schedules { get; }
        IRepository<Project> Projects { get; }
        IRepository<PayRate> PayRates { get; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> CompleteAsync();

        int Complete();
    }
}
