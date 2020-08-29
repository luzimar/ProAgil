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
    public class EventosRepository : BaseContext, IEventosRepository
    {
        private readonly IRepository<Evento> _repository;
        public EventosRepository(IRepository<Evento> repository, ProAgilContext context) : base(context)
        {
            _repository = repository;
        }

        public async Task Adicionar(Evento evento) => await _repository.Add(evento);

        public void Atualizar(Evento entity) => _repository.Update(entity);

        public void Excluir(Evento entity) => _repository.Delete(entity);

        public void ExcluirVarios(Evento[] entity) => _repository.DeleteRange(entity);

        public async Task<bool> Commitar() => await _repository.SaveChanges();

        public async Task<Evento[]> ObterEventos(bool incluiPalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include(x => x.Lotes)
                                                       .Include(x => x.RedesSociais);

            if (incluiPalestrantes)
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

            if (incluiPalestrantes)
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

            if (incluiPalestrantes)
            {
                query = query.Include(x => x.PalestrantesEventos)
                            .ThenInclude(x => x.Palestrante);
            }
            query = query.Where(x => x.Tema.ToLower().Contains(tema.ToLower())).OrderByDescending(x => x.DataEvento);

            return await query.ToArrayAsync();
        }
    }
}