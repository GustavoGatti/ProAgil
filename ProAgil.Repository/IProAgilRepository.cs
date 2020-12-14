using ProAgil.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProAgil.Repository
{
    public interface IProAgilRepository
    {
        //Geral
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        //Eventos
        Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes);
        Task<Evento[]> GetAllEventoAsync(bool includePalestrantes);
        Task<Evento> GetAllEventoAsyncById(int EventoId, bool includePalestrantes);

        //Palestrante

        Task<Palestrante[]> GettAllPalestrantesAsyncByName(string name, bool includeEvento);
        Task<Palestrante> GetAllPalestranteAsync(int PalestranteId, bool includeEvento);

    }
}
