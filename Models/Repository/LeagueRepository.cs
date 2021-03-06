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

        public async Task<int> AddPlayer(Player player)
        {
            if (db != null)
            {
                var count = player.Team.Players.Count(p => p.Team.Id == player.Team.Id);
                if (count < 8)
                {
                    await db.Player.AddAsync(player);
                    await db.SaveChangesAsync();
                }

                return player.PlayerId;
            }

            return 0;
        }

        public async Task<int> AddTeam(Team team)
        {
            if (db != null)
            {
                await db.Team.AddAsync(team);
                await db.SaveChangesAsync();
                return team.Id;
            }

            return 0;
        }

        public async Task<int> DeletePlayer(int? playerId)
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

        public async Task<int> DeleteTeam(int? teamId)
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

        public async Task<LeagueViewModel> GetPlayer(int? playerId)
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
                        TeamID = t.Id,
                        TeamName = t.Name
                    }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<List<LeagueViewModel>> GetPlayers()
        {
            if (db != null)
            {
                return await (from p in db.Player
                    from t in db.Team
                    where p.PlayerId == t.Id
                    select new LeagueViewModel
                    {
                        PlayerId = p.PlayerId,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        TeamID = t.Id,
                        TeamName = t.Name
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
                        TeamID = t.Id,
                        TeamName = t.Name
                    }).ToListAsync();
            }

            return null;
        }

        public async Task<List<LeagueViewModel>> GetPlayersPerTeam(int? teamID)
        {
            if (db != null)
            {
                return await (from p in db.Player
                    from t in db.Team
                    where t.Id == teamID
                    select new LeagueViewModel
                    {
                        PlayerId = p.PlayerId,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        TeamID = t.Id,
                        TeamName = t.Name
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

        public async Task<List<Team>> GetTeamsByLoc(string location)
        {
            if (db != null)
            {
                return await (from t in db.Team
                    where t.Location == location
                    orderby t.Location
                    select new Team
                    {
                        Id = t.Id,
                        Name = t.Name,
                        Location = t.Location
                    }).ToListAsync();
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
                        TeamID = t.Id,
                        TeamName = t.Name,
                    }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<List<LeagueViewModel>> GetTeamByOrder(string orderBy)
        {
            if (db != null)
            {
                var model = new List<LeagueViewModel>();
                if (orderBy?.ToLower() == "location")
                {
                    return await (from t in db.Team
                        orderby t.Location
                        select new LeagueViewModel
                        {
                            TeamLocation = t.Location,
                            TeamName = t.Name
                        }).ToListAsync();
                }
                else if ((orderBy?.ToLower() == "teamname"))
                {
                    return await (from t in db.Team
                        orderby t.Name
                        select new LeagueViewModel
                        {
                            TeamLocation = t.Location,
                            TeamName = t.Name
                        }).ToListAsync();
                }

                return null;
            }

            return null;
        }
    }
}