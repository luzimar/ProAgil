using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain.Interfaces;
using ProAgil.Domain.Models;
using ProAgil.Infra.Data.Context;

namespace ProAgil.Infra.Data.Implementations
{
  public class LotesRepository : Repository<Lote>, ILotesRepository
  {
    public LotesRepository(ProAgilContext context): base(context)
    {}
  }
}