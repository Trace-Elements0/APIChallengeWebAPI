using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIChallengeWebAPI.Models;
using APIChallengeWebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIChallengeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private ILeagueRepository leagueRepository;

        public PlayerController(ILeagueRepository league)
        {
            leagueRepository = league;
        }
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
                var player = await leagueRepository.GetPlayer(playerId);
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
        [HttpGet]
        [Route("GetPlayers")]
        public async Task<IActionResult> GetPlayers()
        {
            try
            {
                var players = await leagueRepository.GetPlayers();
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
                var players = await leagueRepository.GetPlayersByLast(last);
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
                var players = await leagueRepository.GetPlayersPerTeam(teamId);
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
                result = await leagueRepository.DeletePlayer(id);
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
        [HttpPost]
        [Route("AddPlayer")]
        public async Task<IActionResult> AddPlayer([FromBody] Player model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var PlayerId = await leagueRepository.AddPlayer(model);
                    if (PlayerId > 0)
                    {
                        return Ok(PlayerId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }
    }
}
