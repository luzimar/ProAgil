using ProAgil.Domain.Core.Models;

namespace ProAgil.Domain.Models
{
    public class RedeSocial : Entity
    {
        public string Nome { get; set; }
        public string Url { get; set; }
        public int? EventoId { get; set; }
        public Evento Evento { get; }
        public int? PalestranteId { get; set; }
        public Palestrante Palestrante { get; }
    }
}