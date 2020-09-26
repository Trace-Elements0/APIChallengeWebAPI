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

        public async Task<long> DeleteTeam(long? teamId)
        {
            int result = 0;
            if (db != null)
            {
                var team = await db.Team.FirstOrDefaultAsync(x => x.Id == teamId);
                if (team != null)
                {
                    db.Team.Remove(team);
                    result = await db.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        public async Task<LeagueViewModel> GetPlayer(long? playerId)
        {
            if (db != null)
            {
                return await (from p in db.Player
                    from t in db.Team
                    where p.PlayerId == playerId
                    select new LeagueViewModel
                    {
                        PlayerId = p.PlayerId,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        TeamID = p.TeamID,
                        TeamName = t.Name,
                    }).FirstOrDefaultAsync();
            }

            return null;
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
            if (db != null)
            {
                return await (from p in db.Player
                    from t in db.Team
                    where p.LastName == lastName
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

        public async Task<List<LeagueViewModel>> GetPlayersPerTeam(long teamID)
        {
            if (db != null)
            {
                return await (from p in db.Player
                    from t in db.Team
                    where p.TeamID == teamID
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

        public async Task<List<Team>> GetTeams()
        {
            if (db != null)
            {
                return await db.Team.ToListAsync();
            }
            return null;
        }

        public async Task<List<Team>> GetTeamsOrd()
        {
            if (db != null)
            {
                return await db.Team.OrderBy(t=>t.Location).ToListAsync();
            }
            return null;
        }
        public async Task<LeagueViewModel> GetTeam(string teamName) 
        {
            if (db != null)
            {
                return await (from p in db.Player
                    from t in db.Team
                    where t.Name == teamName
                    select new LeagueViewModel
                    {
                        PlayerId = p.PlayerId,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        TeamID = p.TeamID,
                        TeamName = t.Name,
                    }).FirstOrDefaultAsync();
            }

            return null;
        }


    }
}