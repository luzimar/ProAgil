using ProAgil.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProAgil.Test.FakeRepositories.Base
{
    public abstract class BaseContext<T> where T: Entity
    {
        protected readonly IList<T> _context;
        public BaseContext(IList<T> context)
        {
            _context = context;
        }
    }
}
