using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ITProject.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Travel> Travels { get; set; }
    }
}
