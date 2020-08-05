
using System.Collections.Generic;

namespace ProAgil.Domain.Commands.Eventos
{
    public class CommandResponse
    {
        public bool Success { get; set; }
        public List<string> Messages { get; set; } = new List<string>();
    }
}
