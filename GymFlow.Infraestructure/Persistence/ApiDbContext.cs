using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymFlow.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymFlow.Infraestructure.Persistence
{
    public class ApiDbContext : DbContext
    {
        public DbSet<FitnessClass> FitnessClasses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Member> Members { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) 
        { 
        
        }
    }
}
