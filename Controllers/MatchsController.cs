using Microsoft.AspNetCore.Mvc;
using RepartitionTournoi.Domain.Interfaces;
using RepartitionTournoi.Models;
using RepartitionTournoi.Models.Tournoi;

namespace RepartitionTournoi.Services.Controllers;

[ApiController]
[Route("[controller]")]
public class MatchsController : ControllerBase
{
    private readonly IMatchDomain _matchDomain;

    public MatchsController(IMatchDomain matchDomain)
    {
        _matchDomain = matchDomain;
    }

    [HttpGet]
    [Route("BurndownChartLines/{id}")]
    public IEnumerable<BurndownChartLineDTO> GetBurdownChartLines(long id, long? joueurId)
    {
        return _matchDomain.GetBurndownChartLineDTOs(id, joueurId);
    }
    [HttpGet]
    [Route("{matchId}/Tournoi")]
    public TournoiDTO GetByMatchId(long matchId)
    {
        return _matchDomain.GetTournoiByMatchId(matchId);
    }
    [HttpGet]
    [Route("{id}")]
    public MatchDTO GetById(int id)
    {
        return _matchDomain.GetById(id);
    }
    [HttpPut]
    public async Task Update([FromBody] MatchDTO match)
    {
        await _matchDomain.Update(match);
    }
}