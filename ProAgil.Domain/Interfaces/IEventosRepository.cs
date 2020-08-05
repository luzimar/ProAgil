using System.Threading.Tasks;
using ProAgil.Domain.Core.Interfaces;
using ProAgil.Domain.Models;

namespace ProAgil.Domain.Interfaces
{
    public interface IEventosRepository : IRepository<Evento>
    {
         Task<Evento[]> ObterEventos(bool incluiPalestrantes = false);
         Task<Evento> ObterEventoPorId(int id, bool incluiPalestrantes = false);
         Task<Evento[]> ObterEventosPorTema(string tema, bool incluiPalestrantes = false);
    }
}