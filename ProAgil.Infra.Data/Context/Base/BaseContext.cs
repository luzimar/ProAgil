using Microsoft.EntityFrameworkCore;

namespace ProAgil.Infra.Data.Context.Base
{
    public abstract class BaseContext
    {
        protected readonly ProAgilContext _context;

        public BaseContext(ProAgilContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}
