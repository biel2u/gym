using Gym.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Domain.Concrete
{
    public class EFDbContext : IdentityDbContext<User>
    {
        public EFDbContext()
      : base("name=EFDbContext")
        {
        }

        public DbSet<Training> Trainings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
    }
}
