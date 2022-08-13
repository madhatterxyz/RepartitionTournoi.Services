using Microsoft.AspNetCore.Mvc;
using RepartitionTournoi.Domain.Interfaces;
using RepartitionTournoi.Models;

namespace RepartitionTournoi.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TournoisController : ControllerBase
    {

        private readonly ILogger<TournoisController> _logger;
        private readonly ITournoiDomain _tournoiDomain;

        public TournoisController(ILogger<TournoisController> logger, ITournoiDomain TournoiDomain)
        {
            _logger = logger;
            _tournoiDomain = TournoiDomain;
        }

        [HttpGet]
        public async Task<List<TournoiDTO>> All()
        {
            return await _tournoiDomain.All();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<TournoiDTO> Get(long id)
        {
            return await _tournoiDomain.GetById(id);
        }
        [HttpPost]
        public async Task<TournoiDTO> Create(TournoiDTO Tournoi)
        {
            return await _tournoiDomain.Create(Tournoi.Nom);
        }
    }
}