using Microsoft.AspNetCore.Mvc;
using RepartitionTournoi.Domain.Interfaces;
using RepartitionTournoi.Models.Scores;

namespace RepartitionTournoi.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScoresController : ControllerBase
    {

        private readonly ILogger<ScoresController> _logger;
        private readonly IScoreDomain _domain;

        public ScoresController(ILogger<ScoresController> logger, IScoreDomain domain)
        {
            _logger = logger;
            _domain = domain;
        }

        [HttpGet]
        [Route("{matchId}")]
        public async Task<ScoreDTO> Get(long matchId, long joueurId)
        {
            return await _domain.GetById(matchId,joueurId);
        }
        [HttpPut]
        public async Task Update([FromBody] ScoreDTO tournoi)
        {
            await _domain.Update(tournoi);
        }
    }
}