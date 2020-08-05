using ProAgil.Application.Response;
using ProAgil.Application.ViewModels;
using System.Threading.Tasks;

namespace ProAgil.Application.Interfaces
{
    public interface IEventoService
    {
        Task<EventoResponse> CriarEvento(EventoViewModel eventoModel);
        Task<EventoResponse> EditarEvento(EventoViewModel eventoModel);
        Task<EventoResponse> ExcluirEvento(EventoViewModel eventoModel);
        Task<EventoResponse> ObterEventos(bool incluiPalestrantes);
        Task<EventoResponse> ObterEventoPorId(int id, bool incluiPalestrantes);
        Task<EventoResponse> ObterEventosPorTema(string tema, bool incluiPalestrantes);
    }
}
