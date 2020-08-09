using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain.Interfaces;
using ProAgil.Domain.Models;
using ProAgil.Infra.Data.Context;

namespace ProAgil.Infra.Data.Implementations
{
  public class RedesSociaisRepository : Repository<RedeSocial>, IRedesSociaisRepository
  {
    public RedesSociaisRepository(ProAgilContext context): base(context)
    {}
  }
}