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
    public class TeamController : ControllerBase
    {
        private ILeagueRepository leagueRepository;

        public TeamController(ILeagueRepository _leagueRepository)
        {
            leagueRepository = _leagueRepository;
        }
        [HttpGet]
        [Route("GetTeams")]
        public async Task<IActionResult> GetTeams()
        {
            try
            {
                var teams = await leagueRepository.GetTeams();
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
        [HttpGet]
        [Route("GetTeamsOrd")]
        public async Task<IActionResult> GetTeamsOrd(string loc)
        {
            try
            {
                var teams = await leagueRepository.GetTeamsOrd(loc);
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
                var team = await leagueRepository.GetTeam(name);
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
                result = await leagueRepository.DeleteTeam(id);
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
        [HttpPut]
        [Route("AddTeam")]
        public async Task<IActionResult> AddTeam([FromBody] Team model)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var team = await leagueRepository.AddTeam(model);
                if (team > 0)
                {
                    return Ok(team);
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
    }
}
