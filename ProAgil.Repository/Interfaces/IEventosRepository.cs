using System.Threading.Tasks;
using ProAgil.Domain.Models;

namespace ProAgil.Repository.Interfaces
{
    public interface IEventosRepository : IRepository<Evento>
    {
         Task<Evento[]> ObterEventos(bool incluiPalestrantes = false);
         Task<Evento> ObterEventoPorId(int id, bool incluiPalestrantes = false);
         Task<Evento[]> ObterEventosPorTema(string tema, bool incluiPalestrantes = false);
    }
}