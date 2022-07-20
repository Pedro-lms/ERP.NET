using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Pedro.Projects.Data
{
    public class ProjectsDbContextFactory : IDbContextFactory<ProjectsDbContext>
    {
        public ProjectsDbContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<ProjectsDbContext>();
            builder.UseSqlServer("Server=.;Database=Pedro;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new ProjectsDbContext(builder.Options);
        }
    }
}
