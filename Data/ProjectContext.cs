using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }
        public DbSet<Location> locations { get; set; }

    }
}
