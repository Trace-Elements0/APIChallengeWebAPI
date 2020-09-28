using APIChallengeWebAPI.Models;
using APIChallengeWebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIChallengeWebAPI.Repository
{
    public interface ILeagueRepository
    {
        //define methods for different request and responses
        Task<int> AddPlayer(Player player);//create a player
        Task<int> AddTeam(Team team);//create a team
        Task<int> DeletePlayer(int? playerId);//remove a player from a team
        Task<int> DeleteTeam(int? teamId);//
        Task<LeagueViewModel> GetPlayer(int? playerId);//get player by id
        Task<List<LeagueViewModel>> GetPlayers();//get all players
        Task<List<LeagueViewModel>> GetPlayersByLast(string lastName);//get players by last name
        Task<List<LeagueViewModel>> GetPlayersPerTeam(int? teamID); //get players on a team
        Task<List<Team>> GetTeams(); //get all teams
        Task<List<Team>> GetTeamsByLoc(string location); //get teams ordered by name or location
        Task<LeagueViewModel> GetTeam(string teamName); //get team by name
        Task<List<LeagueViewModel>> GetTeamByOrder(string orderBy);



    }
}
