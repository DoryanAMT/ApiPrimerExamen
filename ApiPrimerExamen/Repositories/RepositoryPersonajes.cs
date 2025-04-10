using ApiPrimerExamen.data;
using ApiPrimerExamen.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPrimerExamen.Repositories
{
    public class RepositoryPersonajes
    {
        private SeriesContext context;
        public RepositoryPersonajes(SeriesContext context)
        {
            this.context = context;
        }
        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }
        public async Task<Personaje> FindPersonajeAsync
            (int idPersonaje)
        {
            return await this.context.Personajes
                .FirstOrDefaultAsync(x => x.IdPersonaje == idPersonaje);
        }
        public async Task UpdateSeriePersonajeAsync
            (int idPersonaje, int idSerie)
        {
            Personaje personaje = await FindPersonajeAsync(idPersonaje);
            personaje.IdSerie = idSerie;
            await this.context.SaveChangesAsync();
        }
        public async Task<List<Serie>> GetSeriesAsync()
        {
            return await this.context.Series.ToListAsync();
        }
        public async Task<Serie> FindSerieAsync
            (int idSerie)
        {
            return await this.context.Series
                .FirstOrDefaultAsync(x => x.IdSerie == idSerie);
        }
        public async Task<List<Personaje>> GetPersonajesSerieAsync
            (int idSerie)
        {
            return await this.context.Personajes
                .Where(x => x.IdSerie == idSerie)
                .ToListAsync();
        }
        public async Task<List<Personaje>> GetPersonajesSeriesAsync
            (List<int> ids)
        {
            var consulta = from datos in this.context.Personajes
                           where ids.Contains(datos.IdSerie)
                           select datos;
            return await consulta.ToListAsync();
        }
    }
}
