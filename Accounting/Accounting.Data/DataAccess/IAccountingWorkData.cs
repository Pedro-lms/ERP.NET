using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Accounting.Data.DataAccess.Repositories;
using Accounting.Core.Entities;

namespace Accounting.Data.DataAccess
{
    public interface IAccountingWorkData
    {
        IRepository<Employee> Employees { get; }
        IRepository<Company> Companies { get; }
        IRepository<Invoice> Invoices { get; }
        IRepository<Storehouse> Storehouses { get; }
        IRepository<Bill> Bills { get; }        

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> CompleteAsync();

        int Complete();
    }
}
