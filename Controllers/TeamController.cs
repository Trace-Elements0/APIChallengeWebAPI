using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIChallengeWebAPI.Models;
using APIChallengeWebAPI.Repository;
using APIChallengeWebAPI.ViewModel;

namespace APIChallengeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private ILeagueRepository league;

        public TeamController(ILeagueRepository context)
        {
            league = context;
        }

        // GET: /GetTeams
        [HttpGet]
        [Route("GetTeams")]
        public async Task<IActionResult> GetTeams()
        {
            try
            {
                var teams = await league.GetTeams();
                if (teams == null)
                {
                    return NotFound();
                }

                return Ok(teams);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //GET: /GetPlayer/id
        [HttpGet]
        [Route("GetPlayer")]
        public async Task<IActionResult> GetPlayer(int? playerId)
        {
            if (playerId == null)
            {
                return BadRequest();
            }

            try
            {
                var player = await league.GetPlayer(playerId);
                if (player == null)
                {
                    return NotFound();
                }

                return Ok(player);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //GET: /GetPlayers
        [HttpGet]
        [Route("GetPlayers")]
        public async Task<IActionResult> GetPlayers()
        {
            try
            {
                var players = await league.GetPlayers();
                if (players == null)
                {
                    return NotFound();
                }

                return Ok(players);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //GET: /GetPlayersByLast
        [HttpGet]
        [Route("GetPlayersByLast")]
        public async Task<IActionResult> GetPlayersByLast(string last)
        {
            if (last == null)
            {
                return BadRequest();
            }
            try
            {
                var players = await league.GetPlayersByLast(last);
                if (players == null)
                {
                    return NotFound();
                }

                return Ok(players);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //GET: /GetPlayersPerTeam
        [HttpGet]
        [Route("GetPlayersPerTeam")]
        public async Task<IActionResult> GetPlayersPerTeam(int? teamId)
        {
            if (teamId == null)
            {
                return BadRequest();
            }
            try
            {
                var players = await league.GetPlayersPerTeam(teamId);
                if (players == null)
                {
                    return NotFound();
                }

                return Ok(players);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        //GET: //GetTeamsOrd
        [HttpGet]
        [Route("GetTeamsByLoc")]
        public async Task<IActionResult> GetTeamsByLoc(string loc)
        {
            try
            {
                var teams = await league.GetTeamsByLoc(loc);
                if (teams == null)
                {
                    return NotFound();
                }

                return Ok(teams);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //GET: /GetTeam
        [HttpGet]
        [Route("GetTeam")]
        public async Task<IActionResult> GetTeam(string name)
        {
            if (name == null)
            {
                return BadRequest();
            }

            try
            {
                var team = await league.GetTeam(name);
                if (team == null)
                {
                    return NotFound();
                }

                return Ok(team);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //DELETE: /DeletePlayer
        [HttpDelete]
        [Route("DeletePlayer")]
        public async Task<IActionResult> DeletePlayer(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await league.DeletePlayer(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //DELETE: /DeleteTeam
        [HttpDelete]
        [Route("DeleteTeam")]
        public async Task<IActionResult> DeleteTeam(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await league.DeleteTeam(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //POST: /AddPlayer
        [HttpPost]
        [Route("AddTeam")]//works
        public async Task<ActionResult> AddTeam([FromBody] Team team)//works
        {
            await league.AddTeam(team);
            return CreatedAtAction(nameof(GetTeams), new { id = team.Id }, team);
        }

        [HttpPost]
        [Route("AddPlayer")]//works
        public async Task<ActionResult> AddPlayer([FromBody] Player player)
        {
            await league.AddPlayer(player);
            return CreatedAtAction(nameof(GetPlayers), new { id = player.PlayerId }, player);
        }
    }
}
