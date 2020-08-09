using System.Threading.Tasks;
using ProAgil.Application.ViewModels;

namespace ProAgil.Application.Interfaces
{
    public interface IRedeSocialService
    {
         Task ExcluirRedesSociais(RedeSocialViewModel[] redesSocials);
    }
}