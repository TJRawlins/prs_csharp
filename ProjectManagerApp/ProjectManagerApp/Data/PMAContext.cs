using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManagerApp.Models;

namespace ProjectManagerApp.Data
{
    public class PMAContext : DbContext
    {
        public PMAContext (DbContextOptions<PMAContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = default!;

        public DbSet<Project> Projects { get; set; } = default!;

        public DbSet<ProjectManagerApp.Models.Task> Tasks { get; set; } = default!;
    }
}
