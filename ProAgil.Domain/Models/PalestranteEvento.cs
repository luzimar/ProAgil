using ProAgil.Domain.Core.Models;

namespace ProAgil.Domain.Models
{
    public class PalestranteEvento : Entity
    {
        public int PalestranteId { get; set; }
        public Palestrante Palestrante { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}