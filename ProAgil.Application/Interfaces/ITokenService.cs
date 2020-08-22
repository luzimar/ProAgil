using System.Threading.Tasks;
using ProAgil.Domain.Identity;

namespace ProAgil.Application.Interfaces
{
    public interface ITokenService
    {
         Task<string> Generate(User user, string secret);
    }
}