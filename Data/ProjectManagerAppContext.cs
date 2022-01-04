using System;
using Microsoft.EntityFrameworkCore;
using ProjectManagerApp.Models;

namespace ProjectManagerApp.Data
{
    public class ProjectManagerAppContext : DbContext
    {
        public ProjectManagerAppContext(DbContextOptions<ProjectManagerAppContext> options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Sprint> Sprints { get; set; }

        public DbSet<Task> Tasks { get; set; }
    }
}
