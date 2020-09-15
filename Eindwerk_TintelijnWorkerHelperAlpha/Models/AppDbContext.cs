using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eindwerk_TintelijnWorkerHelperAlpha.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
       // public DbSet<Address> Addresses { get; set; }
       // public DbSet<ConstructionSite> ConstructionSites { get; set; }

       // public DbSet<WorkInput> WorkInputs { get; set; }
    }
}
