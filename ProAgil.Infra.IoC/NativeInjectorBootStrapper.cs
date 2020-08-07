using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProAgil.Application.Interfaces;
using ProAgil.Application.Services;
using ProAgil.Domain.Commands;
using ProAgil.Domain.Commands.Eventos;
using ProAgil.Domain.Interfaces;
using ProAgil.Infra.Data.Implementations;

namespace ProAgil.Infra.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IEventosRepository, EventosRepository>();
            services.AddScoped<IPalestrantesRepository, PalestrantesRepository>();
            services.AddScoped<IEventoService, EventoService>();
            services.AddScoped<IRequestHandler<CriarEventoCommand, CommandResponse>, EventoCommandHandler>();
            services.AddScoped<IRequestHandler<EditarEventoCommand, CommandResponse>, EventoCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirEventoCommand, CommandResponse>, EventoCommandHandler>();
        }
    }
}
