
using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DevFreela.Infrastructure.Persistence
{
    public class IRepositoryProject : DbContext
    {
        public IRepositoryProject(DbContextOptions<IRepositoryProject> options) : base(options)
        {
           
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
