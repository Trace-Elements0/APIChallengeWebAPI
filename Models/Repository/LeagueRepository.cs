using System.Collections.Generic;
using System.Threading.Tasks;
using APIChallengeWebAPI.Models;
using APIChallengeWebAPI.ViewModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            if (db != null)
            {
                await db.Player.AddAsync(player);
                await db.SaveChangesAsync();
                return player.PlayerId;
            }

            return 0;
        }

        public async Task<long> AddTeam(Team team)
        {
            if (db != null)
            {
                await db.Team.AddAsync(team);
                await db.SaveChangesAsync();
                return team.Id;
            }
            return 0;
        }

        public async Task<long> DeletePlayer(long? playerId)
        {
            int result = 0;
            if (db != null)
            {
                var player = await db.Player.FirstOrDefaultAsync(x => x.PlayerId == playerId);
                if (player != null)
                {
                    db.Player.Remove(player);
                    result = await db.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        public async Task<long> DeleteTeam(long? teamId, Team team)
        {

        }

        public async Task<LeagueViewModel> GetPlayer(long? playerId)
        {

        }

        public async Task<List<LeagueViewModel>> GetPlayers()
        {
            if (db!=null)
            {
                return await (from p in db.Player
                    from t in db.Team
                    where p.PlayerId == t.Id
                    select new LeagueViewModel
                    {
                        PlayerId = p.PlayerId,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        TeamID = p.TeamID,
                        TeamName = t.Name,
                    }).ToListAsync();
            }
            return null;
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