using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pedro.Companies.Core.Entities;
using Pedro.Companies.Data.DataAccess.Repositories;

namespace Pedro.Companies.Data.DataAccess
{
    public interface ICompanyWorkData
    {        
        IRepository<ApplicationUser> Users { get; }        
        IRepository<Company> Companies { get; }
        IRepository<Employee> Employees { get; }
        IRepository<Inquiry> Inquiries { get; }
        IRepository<Settings> Settings { get; }
        IRepository<RegistrationRequestMessage> RegistrationRequestMessages { get; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> CompleteAsync();

        int Complete();
    }
}
