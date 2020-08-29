using System.Threading.Tasks;
using ProAgil.Domain.Models;

namespace ProAgil.Domain.Interfaces
{
    public interface IEventosRepository
    {
        Task Adicionar(Evento evento);
        void Atualizar(Evento entity);
        void Excluir(Evento entity);
        void ExcluirVarios(Evento[] entity);
        Task<bool> Commitar();
        Task<Evento[]> ObterEventos(bool incluiPalestrantes = false);
        Task<Evento> ObterEventoPorId(int id, bool incluiPalestrantes = false);
        Task<Evento[]> ObterEventosPorTema(string tema, bool incluiPalestrantes = false);
    }
}