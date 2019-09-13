using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachersGuide.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<BehaviourPageOne> BehaviourPageOne { get; set; }
        public DbSet<BehaviorPageTow> BehaviorPageTow { get; set; }
        public DbSet<InterventionsModified> InterventionsModified { get; set; }
    }
}
