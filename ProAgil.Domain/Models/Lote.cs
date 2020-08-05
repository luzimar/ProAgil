using ProAgil.Domain.Core.Models;
using System;

namespace ProAgil.Domain.Models
{
    public class Lote : Entity
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int Quantidade { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; }

    }
}