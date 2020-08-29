using System.Threading.Tasks;
using ProAgil.Domain.Models;

namespace ProAgil.Domain.Interfaces
{
    public interface IRedesSociaisRepository 
    {
        void ExcluirVarias(RedeSocial[] entity);
        Task<bool> Commitar();
    }
}