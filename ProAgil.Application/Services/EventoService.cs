using AutoMapper;
using MediatR;
using ProAgil.Application.Interfaces;
using ProAgil.Application.Response;
using ProAgil.Application.Services.Base;
using ProAgil.Application.ViewModels;
using ProAgil.Domain.Commands.Eventos;
using ProAgil.Domain.Interfaces;
using System.Threading.Tasks;

namespace ProAgil.Application.Services
{
    public class EventoService : BaseService<EventoResponse>, IEventoService
    {
        private readonly IMediator _mediator;
        private readonly IEventosRepository _repository;
        private readonly IMapper _mapper;
        public EventoService(IMediator mediator, IEventosRepository repository, IMapper mapper)
        {
            _mediator = mediator;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EventoResponse> CriarEvento(EventoViewModel evento)
        {
            var command = _mapper.Map<CriarEventoCommand>(evento);
            var commandResponse = await _mediator.Send(command);
            Response.Success = commandResponse.Success;
            Response.InnerResponse.Messages = commandResponse.Messages;
            return Response;
        }

        public async Task<EventoResponse> EditarEvento(EventoViewModel evento)
        {
            var command = _mapper.Map<EditarEventoCommand>(evento);
            var commandResponse = await _mediator.Send(command);
            Response.Success = commandResponse.Success;
            Response.InnerResponse.Messages = commandResponse.Messages;
            return Response;
        }

        public async Task<EventoResponse> ExcluirEvento(EventoViewModel evento)
        {
            var command = _mapper.Map<ExcluirEventoCommand>(evento);
            var commandResponse = await _mediator.Send(command);
            Response.Success = commandResponse.Success;
            Response.InnerResponse.Messages = commandResponse.Messages;
            return Response;
        }

        public async Task<EventoResponse> ObterEventoPorId(int id, bool incluiPalestrantes)
        {
            var evento = await _repository.ObterEventoPorId(id, incluiPalestrantes);
            Response.Evento = _mapper.Map<EventoViewModel>(evento);
            return Response;
        }

        public async Task<EventoResponse> ObterEventos(bool incluiPalestrantes)
        {
            var eventos = await _repository.ObterEventos(incluiPalestrantes);
            Response.Eventos = _mapper.Map<EventoViewModel[]>(eventos);
            return Response;
        }

        public async Task<EventoResponse> ObterEventosPorTema(string tema, bool incluiPalestrantes)
        {
            var eventos = await _repository.ObterEventosPorTema(tema, incluiPalestrantes);
            Response.Eventos = _mapper.Map<EventoViewModel[]>(eventos);
            return Response;
        }
    }
}
