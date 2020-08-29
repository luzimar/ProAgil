using ProAgil.Domain.Core.Interfaces;
using ProAgil.Domain.Interfaces;
using ProAgil.Domain.Models;
using ProAgil.Infra.Data.Context;
using ProAgil.Infra.Data.Context.Base;
using System.Threading.Tasks;

namespace ProAgil.Infra.Data.Implementations
{
    public class LotesRepository : BaseContext, ILotesRepository
    {
        private readonly IRepository<Lote> _repository;
        public LotesRepository(IRepository<Lote> repository, ProAgilContext context) : base(context)
        {
            _repository = repository;
        }
        public void ExcluirVarios(Lote[] entity) => _repository.DeleteRange(entity);
        public async Task<bool> Commitar() => await _repository.SaveChanges();
    }
}