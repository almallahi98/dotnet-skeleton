using Microsoft.EntityFrameworkCore;
using Domin;
namespace Presistence
{

    public class DbContextApp : DbContext
    {
        public DbContextApp(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Activity> Activities{set;get; }
    }
}