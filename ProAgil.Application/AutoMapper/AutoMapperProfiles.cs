using AutoMapper;
using ProAgil.Application.Response;
using ProAgil.Application.ViewModels;
using ProAgil.Domain.Commands;
using ProAgil.Domain.Commands.Eventos;
using ProAgil.Domain.Commands.Palestrantes;
using ProAgil.Domain.Identity;
using ProAgil.Domain.Models;
using ProAgil.Domain.Response;
using ProAgil.Domain.ValueObjects;
using System.Linq;

namespace ProAgil.Application.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Evento, EventoViewModel>().ForMember(dest => dest.Palestrantes, opt =>
            {
                opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Palestrante).ToList());
            }).ForMember(dest => dest.QtdPessoas, opt =>
            {
                opt.MapFrom(src => src.QtdPessoas.Quantidade);
            }).ForMember(dest => dest.Email, opt =>
            {
                opt.MapFrom(src => src.Email.Address);
            }).ForMember(dest => dest.DataEvento, opt => {
                opt.MapFrom(src => src.DataEvento.ToString("dd/MM/yyyy HH:mm"));
            }).ReverseMap();

            CreateMap<Palestrante, PalestranteViewModel>().ForMember(dest => dest.Eventos, opt =>
            {
                opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Evento).ToList());
            }).ForMember(dest => dest.Email, opt =>
            {
                opt.MapFrom(src => src.Email.Address);
            }).ReverseMap();

            CreateMap<CriarEventoCommand, EventoViewModel>().ReverseMap();
            CreateMap<EditarEventoCommand, EventoViewModel>().ReverseMap();
            CreateMap<ExcluirEventoCommand, EventoViewModel>().ReverseMap();

            CreateMap<CriarPalestranteEventoCommand, PalestranteViewModel>().ReverseMap();

            CreateMap<Lote, LoteViewModel>().ReverseMap();
            CreateMap<RedeSocial, RedeSocialViewModel>().ReverseMap();

            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<User, UserLoginViewModel>().ReverseMap();
        }
    }
}
