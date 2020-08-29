using System.Threading.Tasks;
using ProAgil.Domain.Core.Interfaces;
using ProAgil.Domain.Models;

namespace ProAgil.Domain.Interfaces
{
    public interface ILotesRepository
    {
        void ExcluirVarios(Lote[] entity);
        Task<bool> Commitar();
    }
}