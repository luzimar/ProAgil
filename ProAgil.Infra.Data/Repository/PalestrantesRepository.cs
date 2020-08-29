using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain.Core.Interfaces;
using ProAgil.Domain.Interfaces;
using ProAgil.Domain.Models;
using ProAgil.Infra.Data.Context;
using ProAgil.Infra.Data.Context.Base;

namespace ProAgil.Infra.Data.Implementations
{
    public class PalestrantesRepository : BaseContext, IPalestrantesRepository
    {
        private readonly IRepository<Palestrante> _repository;
        public PalestrantesRepository(IRepository<Palestrante> repository, ProAgilContext context) : base(context)
        {
            _repository = repository;
        }

        public async Task Adicionar(Palestrante palestrante) => await _repository.Add(palestrante);

        public void Atualizar(Palestrante palestrante) => _repository.Update(palestrante);

        public void Excluir(Palestrante palestrante) => _repository.Delete(palestrante);

        public async Task<bool> Commitar() => await _repository.SaveChanges();

        public async Task<Palestrante[]> ObterPalestrantes(bool incluiEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(x => x.RedesSociais);

            if (incluiEventos)
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

            if (incluiEventos)
            {
                query = query.Include(x => x.PalestrantesEventos)
                            .ThenInclude(x => x.Evento);
            }
            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Palestrante[]> ObterPalestrantesPorNome(string nome, bool incluiEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(x => x.RedesSociais);

            if (incluiEventos)
            {
                query = query.Include(x => x.PalestrantesEventos)
                            .ThenInclude(x => x.Evento);
            }
            query = query.Where(x => x.Nome.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }


    }
}