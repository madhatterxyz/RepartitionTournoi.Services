using Microsoft.AspNetCore.Mvc;
using RepartitionTournoi.Domain;
using RepartitionTournoi.Models;

namespace RepartitionTournoi.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JoueursController : ControllerBase
    {

        private readonly ILogger<JoueursController> _logger;
        private readonly IJoueurDomain _joueurDomain;

        public JoueursController(ILogger<JoueursController> logger, IJoueurDomain joueurDomain)
        {
            _logger = logger;
            _joueurDomain = joueurDomain;
        }

        [HttpGet]
        public async Task<IEnumerable<JoueurDTO>> GetAll()
        {
            return await _joueurDomain.GetAll();
        }
        [HttpPost]
        public async Task<JoueurDTO> Create(JoueurDTO joueur)
        {
            return await _joueurDomain.Create(joueur);
        }
        [HttpPut]
        public async Task<JoueurDTO> Update(JoueurDTO joueur)
        {
            return await _joueurDomain.Update(joueur);
        }
        [HttpDelete]
        public async Task Delete(long id)
        {
            await _joueurDomain.Delete(id);
        }
    }
}