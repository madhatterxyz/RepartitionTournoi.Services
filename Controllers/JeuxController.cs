using Microsoft.AspNetCore.Mvc;
using RepartitionTournoi.Domain.Interfaces;
using RepartitionTournoi.Models;

namespace RepartitionTournoi.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JeuxController : ControllerBase
    {

        private readonly ILogger<JeuxController> _logger;
        private readonly IJeuDomain _JeuDomain;

        public JeuxController(ILogger<JeuxController> logger, IJeuDomain JeuDomain)
        {
            _logger = logger;
            _JeuDomain = JeuDomain;
        }

        [HttpGet]
        public async Task<IEnumerable<JeuDTO>> GetAll()
        {
            return await _JeuDomain.GetAll();
        }
        [HttpPost]
        public async Task<JeuDTO> Create(JeuDTO Jeu)
        {
            return await _JeuDomain.Create(Jeu);
        }
        [HttpPut]
        public async Task<JeuDTO> Update(JeuDTO Jeu)
        {
            return await _JeuDomain.Update(Jeu);
        }
        [HttpDelete]
        public async Task Delete(long id)
        {
            await _JeuDomain.Delete(id);
        }
    }
}