using MediatR;
using ProAgil.Domain.Commands.Eventos;
using ProAgil.Domain.Models;
using ProAgil.Domain.Response;
using System.Collections.Generic;

namespace ProAgil.Domain.Commands.Palestrantes
{
    public class CriarPalestranteEventoCommand : IRequest<PalestranteResponse>
    {
        public string Nome { get; private set; }
        public string MiniCurriculo { get; private set; }
        public string ImagemUrl { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public List<RedeSocial> RedesSociais { get; set; }
        public List<CriarEventoCommand> Eventos { get; set; }
    }
}
