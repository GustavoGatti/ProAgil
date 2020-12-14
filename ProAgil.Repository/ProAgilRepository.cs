using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProAgil.Repository
{
    public class ProAgilRepository : IProAgilRepository
    {
        private readonly ProAgilContext _context;
        public ProAgilRepository(ProAgilContext context)
        {
            this._context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
           return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include(c => c.Lote).Include(c => c.redeSocial);

            if (includePalestrantes)
            {
                query = query.Include(p => p.palestranteEventos).ThenInclude(p => p.palestrante);
            }
            query = query.AsNoTracking()
                .OrderByDescending(c => c.DataEvento);

            return await query.ToArrayAsync();

        }

        public async Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include(c => c.Lote).Include(c => c.redeSocial);

            if (includePalestrantes)
            {
                query = query.Include(p => p.palestranteEventos).ThenInclude(p => p.palestrante);
            }
            query = query.AsNoTracking()
                .OrderByDescending(c => c.DataEvento).Where(c => c.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

       

        public async Task<Evento> GetAllEventoAsyncById(int EventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include(c => c.Lote).Include(c => c.redeSocial);

            if (includePalestrantes)
            {
                query = query.Include(p => p.palestranteEventos).ThenInclude(p => p.palestrante);
            }
            query = query.AsNoTracking()
                .OrderByDescending(c => c.DataEvento).Where(c => c.EventoId == EventoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante> GetAllPalestranteAsync(int PalestranteId, bool includeEvento = false)
        {
            IQueryable<Palestrante> query = _context.palestrantes.Include(c => c.RedesSociais);

            if (includeEvento)
            {
                query = query.Include(p => p.palestranteEventos).ThenInclude(p => p.evento);
            }
            query = query.AsNoTracking()
                .OrderByDescending(c => c.Nome).Where(c => c.Id == PalestranteId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> GettAllPalestrantesAsyncByName(string name,bool includeEvento = false)
        {
            IQueryable<Palestrante> query = _context.palestrantes.Include(c => c.RedesSociais);

            if (includeEvento)
            {
                query = query.Include(p => p.palestranteEventos).ThenInclude(p => p.evento);
            }
            query = query.AsNoTracking()
                .Where(p => p.Nome.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();

        }

     

      
    }
}
