using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain.Interfaces;
using ProAgil.Domain.Models;
using ProAgil.Infra.Data.Context;

namespace ProAgil.Infra.Data.Implementations
{
  public class EventosRepository : Repository<Evento>, IEventosRepository
  {
    public EventosRepository(ProAgilContext context): base(context)
    {}

    public async Task<Evento[]> ObterEventos(bool incluiPalestrantes = false)
    {
        IQueryable<Evento> query = _context.Eventos.Include(x => x.Lotes)
                                                   .Include(x => x.RedesSociais);

        if(incluiPalestrantes)
        {
            query = query.Include(x => x.PalestrantesEventos)
                        .ThenInclude(x => x.Palestrante);
        }
        query = query.OrderByDescending(x => x.DataEvento);

        return await query.ToArrayAsync();
    }
    
    public async Task<Evento> ObterEventoPorId(int eventoId, bool incluiPalestrantes = false)
    {
        IQueryable<Evento> query = _context.Eventos.Include(x => x.Lotes)
                                                    .Include(x => x.RedesSociais);

        if(incluiPalestrantes)
        {
            query = query.Include(x => x.PalestrantesEventos)
                        .ThenInclude(x => x.Palestrante);
        }
        query = query.Where(x => x.Id == eventoId).OrderByDescending(x => x.DataEvento);

        return await query.FirstOrDefaultAsync();
    }

    public async Task<Evento[]> ObterEventosPorTema(string tema, bool incluiPalestrantes = false)
    {
        IQueryable<Evento> query = _context.Eventos.Include(x => x.Lotes)
                                                    .Include(x => x.RedesSociais);

        if(incluiPalestrantes)
        {
            query = query.Include(x => x.PalestrantesEventos)
                        .ThenInclude(x => x.Palestrante);
        }
        query = query.Where(x => x.Tema.ToLower().Contains(tema.ToLower())).OrderByDescending(x => x.DataEvento);

        return await query.ToArrayAsync();
    }
  }
}