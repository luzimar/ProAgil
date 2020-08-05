using AutoMapper;
using MediatR;
using ProAgil.Domain.Commands.Base;
using ProAgil.Domain.Commands.Eventos;
using ProAgil.Domain.Interfaces;
using ProAgil.Domain.Models;
using ProAgil.Domain.ValueObjects;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProAgil.Domain.Commands
{
    public class EventoCommandHandler : BaseCommandHandler<CommandResponse>, 
        IRequestHandler<CriarEventoCommand, CommandResponse>,
        IRequestHandler<EditarEventoCommand, CommandResponse>,
        IRequestHandler<ExcluirEventoCommand, CommandResponse>

    {
        private readonly IEventosRepository _repository;
        public EventoCommandHandler(IEventosRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> Handle(CriarEventoCommand command, CancellationToken cancellationToken)
        {
            var qtdPessoas = new QuantidadePessoas(command.QtdPessoas);
            var email = new Email(command.Email);

            var evento = new Evento(null, command.Local, Convert.ToDateTime(command.DataEvento), command.Tema, qtdPessoas, command.ImagemUrl, command.Telefone, email);
            if (evento.Valid)
            {
                await _repository.Add(evento);
                if (await _repository.SaveChanges())
                {
                    Response.Success = true;
                    Response.Messages.Add("Evento criado com sucesso!");
                    return Response;
                }
            }
            Response.Success = false;
            Response.Messages.AddRange(evento.Notifications.Select(x => x.Message));
            return Response;
        }

        public async Task<CommandResponse> Handle(EditarEventoCommand command, CancellationToken cancellationToken)
        {
            var qtdPessoas = new QuantidadePessoas(command.QtdPessoas);
            var email = new Email(command.Email);

            var evento = new Evento(command.Id, command.Local, Convert.ToDateTime(command.DataEvento), command.Tema, qtdPessoas, command.ImagemUrl, command.Telefone, email);
            if (evento.Valid)
            {
                _repository.Update(evento);
                if (await _repository.SaveChanges())
                {
                    Response.Success = true;
                    Response.Messages.Add("Evento editado com sucesso!");
                    return Response;
                }
            }
            Response.Success = false;
            Response.Messages.AddRange(evento.Notifications.Select(x => x.Message));
            return Response;
        }

        public async Task<CommandResponse> Handle(ExcluirEventoCommand command, CancellationToken cancellationToken)
        {
            var qtdPessoas = new QuantidadePessoas(command.QtdPessoas);
            var email = new Email(command.Email);

            var evento = new Evento(command.Id, command.Local, Convert.ToDateTime(command.DataEvento), command.Tema, qtdPessoas, command.ImagemUrl, command.Telefone, email);
            
            _repository.Delete(evento);
            if (await _repository.SaveChanges())
            {
                Response.Success = true;
                Response.Messages.Add("Evento excluído com sucesso!");
                return Response;
            }
            Response.Success = false;
            Response.Messages.AddRange(evento.Notifications.Select(x => x.Message));
            return Response;
        }
    }
}
