using MediatR;
using ProAgil.Domain.Commands.Palestrantes;
using ProAgil.Domain.Models;
using System.Collections.Generic;

namespace ProAgil.Domain.Commands.Eventos
{
    public class CriarEventoCommand : IRequest<CommandResponse>
    {
        public string Local { get; set; }
        public string DataEvento { get; set; }
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public string ImagemUrl { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public List<Lote> Lotes { get; set; }
        public List<RedeSocial> RedesSociais { get; set; }
        public List<CriarPalestranteEventoCommand> Palestrantes { get; set; }
    }
}
