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
        Task<long> AddPlayer(Player player);//create a player
        Task<long> AddTeam(Team team);//create a team

        Task<long> DeletePlayer(long? playerId);//remove a player from a team
        Task<long> DeleteTeam(long? teamId);//
        Task<LeagueViewModel> GetPlayer(long? playerId);//get player by id
        Task<List<LeagueViewModel>> GetPlayers();//get all players
        Task<List<LeagueViewModel>> GetPlayersByLast(string lastName);//get players by last name
        Task<List<LeagueViewModel>> GetPlayersPerTeam(long teamID); //get players on a team
        Task<List<Team>> GetTeams(); //get all teams
        Task<List<Team>> GetTeamsOrd(string location); //get teams ordered by name or location
        Task<LeagueViewModel> GetTeam(string teamName); //get team by name
        


    }
}
