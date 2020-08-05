
using ProAgil.Application.Response.Base;
using ProAgil.Application.ViewModels;
using ProAgil.Domain.Models;

namespace ProAgil.Application.Response
{
    public class EventoResponse : BaseResponse
    {
        public EventoViewModel Evento { get; set; }
        public EventoViewModel[] Eventos { get; set; }
    }
}
