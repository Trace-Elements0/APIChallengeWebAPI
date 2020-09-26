using Microsoft.EntityFrameworkCore;

namespace APIChallengeWebAPI.Models
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {

        }
        public APIDbContext()
        {

        }
        public DbSet<Player> Player { get; set; }
        public DbSet<Team> Team { get; set; }
    }
}
