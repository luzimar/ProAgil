using Microsoft.EntityFrameworkCore;
using ProAgil.Domain.Core.Interfaces;
using ProAgil.Domain.Interfaces;
using ProAgil.Domain.Models;
using ProAgil.Test.FakeRepositories.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProAgil.Test.FakeRepositories
{
    public class EventosFakeRepository : BaseContext<Evento>, IEventosRepository
    {
        private readonly IRepository<Evento> _repository;
        public EventosFakeRepository(IRepository<Evento> repository, IList<Evento> context) : base(context)
        {
            _repository = repository;
        }

        public Task Adicionar(Evento evento) => _repository.Add(evento);
        public void Atualizar(Evento evento) => _repository.Update(evento);
        public void Excluir(Evento evento) => _repository.Delete(evento);
        public void ExcluirVarios(Evento[] eventos) => _repository.DeleteRange(eventos);
        public async Task<bool> Commitar() => await _repository.SaveChanges();
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
