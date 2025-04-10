using ApiPrimerExamen.Models;
using ApiPrimerExamen.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPrimerExamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private RepositoryPersonajes repo;
        public SeriesController(RepositoryPersonajes repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Serie>>> Series()
        {
            return await this.repo.GetSeriesAsync();
        }
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<Serie>> FindSeries
            (int id)
        {
            return await this.repo.FindSerieAsync(id);
        }
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<List<Personaje>>> PersonajesSerie
            (int id)
        {
            return await this.repo.GetPersonajesSerieAsync(id);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Personaje>>> PersonajesSeries
            ([FromQuery] List<int> ids)
        {
            return await this.repo.GetPersonajesSeriesAsync(ids);
        }
    }
}
