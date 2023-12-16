using Microsoft.AspNetCore.Mvc;
using RepartitionTournoi.Domain.Interfaces;
using RepartitionTournoi.Models.Tournoi;

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
        public List<TournoiDTO> All()
        {
            return _tournoiDomain.All();
        }
        [HttpGet]
        [Route("{id}")]
        public TournoiDTO Get(long id)
        {
            return _tournoiDomain.GetById(id);
        }
        [HttpPost]
        public async Task<TournoiDTO> Create([FromBody]string nom)
        {
            return await _tournoiDomain.Create(nom);
        }
        [HttpPut]
        public async Task Update([FromBody] EditTournoiDTO tournoi)
        {
            await _tournoiDomain.Update(tournoi);
        }
    }
}