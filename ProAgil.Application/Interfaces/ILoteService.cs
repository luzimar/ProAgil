using System.Threading.Tasks;
using ProAgil.Application.ViewModels;

namespace ProAgil.Application.Interfaces
{
    public interface ILoteService
    {
         Task ExcluirLotes(LoteViewModel[] lotes);
    }
}