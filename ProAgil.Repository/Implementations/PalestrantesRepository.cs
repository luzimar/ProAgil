using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain.Models;
using ProAgil.Repository.Context;
using ProAgil.Repository.Interfaces;

namespace ProAgil.Repository.Implementations
{
  public class PalestrantesRepository : Repository<Palestrante>, IPalestrantesRepository
  {
    public PalestrantesRepository(ProAgilContext context) : base(context)
    {}

    public async Task<Palestrante[]> ObterPalestrantes(bool incluiEventos = false)
    {
        IQueryable<Palestrante> query = _context.Palestrantes.Include(x => x.RedesSociais);

        if(incluiEventos)
        {
            query = query.Include(x => x.PalestrantesEventos)
                         .ThenInclude(x => x.Evento);
        }
        query = query.OrderBy(x => x.Nome);

        return await query.ToArrayAsync();
    }
    public async Task<Palestrante> ObterPalestrantePorId(int id, bool incluiEventos = false)
    {
        IQueryable<Palestrante> query = _context.Palestrantes.Include(x => x.RedesSociais);

        if(incluiEventos)
        {
            query = query.Include(x => x.PalestrantesEventos)
                        .ThenInclude(x => x.Evento);
        }
        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Palestrante[]> ObterPalestrantesPorNome(string nome, bool incluiEventos = false)
    {
        IQueryable<Palestrante> query = _context.Palestrantes.Include(x => x.RedesSociais);

        if(incluiEventos)
        {
            query = query.Include(x => x.PalestrantesEventos)
                        .ThenInclude(x => x.Evento);
        }
        query = query.Where(x => x.Nome.ToLower().Contains(nome.ToLower()));
        return await query.ToArrayAsync();
    }
  }
}