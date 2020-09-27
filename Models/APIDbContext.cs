using Microsoft.EntityFrameworkCore;
using APIChallengeWebAPI.ViewModel;

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
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<Team> Team { get; set; }
    }
}
