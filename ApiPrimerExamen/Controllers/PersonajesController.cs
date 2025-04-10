using ApiPrimerExamen.Models;
using ApiPrimerExamen.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPrimerExamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositoryPersonajes repo;
        public PersonajesController(RepositoryPersonajes repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> Personajes()
        {
            return await this.repo.GetPersonajesAsync();
        }
        [HttpPut]
        [Route("[action]/{idPersonaje}/{idSerie}")]
        public async Task<ActionResult> UpdateSeriePersonaje
            (int idPersonaje, int idSerie)
        {

            await this.repo.UpdateSeriePersonajeAsync(idPersonaje, idSerie);
            return Ok();
        }
    }
}
