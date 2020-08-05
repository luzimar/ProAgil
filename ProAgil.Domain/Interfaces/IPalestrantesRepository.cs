using System.Threading.Tasks;
using ProAgil.Domain.Core.Interfaces;
using ProAgil.Domain.Models;

namespace ProAgil.Domain.Interfaces
{
    public interface IPalestrantesRepository : IRepository<Palestrante>
    {
         Task<Palestrante[]> ObterPalestrantes(bool incluiEventos = false);
         Task<Palestrante> ObterPalestrantePorId(int id, bool incluiEventos = false);
         Task<Palestrante[]> ObterPalestrantesPorNome(string nome, bool incluiEventos = false);
    }
}