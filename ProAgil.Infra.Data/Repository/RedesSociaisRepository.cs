using System.Threading.Tasks;
using ProAgil.Domain.Core.Interfaces;
using ProAgil.Domain.Interfaces;
using ProAgil.Domain.Models;
using ProAgil.Infra.Data.Context;
using ProAgil.Infra.Data.Context.Base;

namespace ProAgil.Infra.Data.Implementations
{
    public class RedesSociaisRepository : BaseContext, IRedesSociaisRepository
    {
        private readonly IRepository<RedeSocial> _repository;
        public RedesSociaisRepository(IRepository<RedeSocial> repository, ProAgilContext context) : base(context)
        {
            _repository = repository;
        }

        public void ExcluirVarias(RedeSocial[] entity) => _repository.DeleteRange(entity);
        public async Task<bool> Commitar() => await _repository.SaveChanges();

    }
}