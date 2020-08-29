using System.Threading.Tasks;
using ProAgil.Domain.Core.Interfaces;
using ProAgil.Domain.Models;

namespace ProAgil.Domain.Interfaces
{
    public interface IPalestrantesRepository
    {
        Task Adicionar(Palestrante palestrante);
        void Atualizar(Palestrante palestrante);
        void Excluir(Palestrante palestrante);
        Task<bool> Commitar();
        Task<Palestrante[]> ObterPalestrantes(bool incluiEventos = false);
        Task<Palestrante> ObterPalestrantePorId(int id, bool incluiEventos = false);
        Task<Palestrante[]> ObterPalestrantesPorNome(string nome, bool incluiEventos = false);
    }
}