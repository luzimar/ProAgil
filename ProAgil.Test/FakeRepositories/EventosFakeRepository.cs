using Microsoft.EntityFrameworkCore;
using ProAgil.Domain.Interfaces;
using ProAgil.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProAgil.Test.FakeRepositories
{
    public class EventosFakeRepository : Repository<Evento>, IEventosRepository
    {

        public EventosFakeRepository(IList<Evento> context) : base(context)
        { }

        public Task<Evento> ObterEventoPorId(int id, bool incluiPalestrantes = false)
        {
            IQueryable<Evento> query = _context.AsQueryable().Include(x => x.Lotes)
                                                             .Include(x => x.RedesSociais);

            if (incluiPalestrantes)
            {
                query = query.Include(x => x.PalestrantesEventos)
                            .ThenInclude(x => x.Palestrante);
            }
            query = query.Where(x => x.Id == id).OrderByDescending(x => x.DataEvento);

            return Task.FromResult(query.FirstOrDefault());
        }

        public Task<Evento[]> ObterEventos(bool incluiPalestrantes = false)
        {
            IQueryable<Evento> query = _context.AsQueryable().Include(x=>x.Lotes)
                                                             .Include(x => x.RedesSociais);

            if (incluiPalestrantes)
            {
                query = query.Include(x => x.PalestrantesEventos)
                            .ThenInclude(x => x.Palestrante);
            }
            query = query.OrderByDescending(x => x.DataEvento);

            return Task.FromResult(query.ToArray());
        }

        public Task<Evento[]> ObterEventosPorTema(string tema, bool incluiPalestrantes = false)
        {
            IQueryable<Evento> query = _context.AsQueryable().Include(x => x.Lotes)
                                                             .Include(x => x.RedesSociais);

            if (incluiPalestrantes)
            {
                query = query.Include(x => x.PalestrantesEventos)
                            .ThenInclude(x => x.Palestrante);
            }
            query = query.Where(x => x.Tema.ToLower().Contains(tema.ToLower())).OrderByDescending(x => x.DataEvento);

            return Task.FromResult(query.ToArray());
        }
    }
}
