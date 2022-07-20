using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Pedro.Projects.Core.Entities;
using Pedro.Projects.Data.Configurations;

namespace Pedro.Projects.Data
{
    public class ProjectsDbContext : DbContext
    {
        public ProjectsDbContext(DbContextOptions<ProjectsDbContext> options) 
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("Projects");
            this.RegesterEntityTypeConfigurations(builder);

            base.OnModelCreating(builder);
        }

        private void RegesterEntityTypeConfigurations(ModelBuilder builder)
        {
            var typesToRegister = Assembly.Load(new AssemblyName("Pedro.Projects.Data")).GetTypes().Where(
                type => type.GetTypeInfo().BaseType != null &&
                !type.GetTypeInfo().IsAbstract &&
                typeof(IEntityTypeConfiguration).IsAssignableFrom(type));

            foreach (var type in typesToRegister)
            {
                Activator.CreateInstance(type, builder);
            }
        }        
    }
}
