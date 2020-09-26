using System.Collections.Generic;
using System.Threading.Tasks;
using APIChallengeWebAPI.Models;
using APIChallengeWebAPI.ViewModel;

namespace APIChallengeWebAPI.Repository
{
    public class LeagueRepository : ILeagueRepository
    {
        APIDbContext db;

        public LeagueRepository(APIDbContext _db)
        {
            db = _db;
        }

        public async Task<long> AddPlayer(Player player)
        {
            
        }

        public async Task<long> AddTeam(Team team)
        {

        }

        public async Task<long> DeletePlayer(long? playerId, Team team)
        {

        }

        public async Task<long> DeleteTeam(long? teamId, Team team)
        {

        }

        public async Task<LeagueViewModel> GetPlayer(long? playerId)
        {

        }

        public async Task<List<LeagueViewModel>> GetPlayers()
        {

        }

        public async Task<List<LeagueViewModel>> GetPlayersByLast(string lastName)
        {

        }

        public async Task<List<Player>> GetPlayersPerTeam(Team team)
        {

        }

        public async Task<List<Team>> GetTeams()
        {
            if (db != null)
            {
                return await db.Team.ToListAsync();
            }
            return null;
        }

            public async Task<List<Team>> GetTeamsOrd(string location = "(location)", string name = "(name)")
        {

        }
        public async Task<LeagueViewModel> GetTeam(string teamName) 
        {

        }


    }
}