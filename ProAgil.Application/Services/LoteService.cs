using System.Threading.Tasks;
using AutoMapper;
using ProAgil.Application.Interfaces;
using ProAgil.Application.ViewModels;
using ProAgil.Domain.Interfaces;
using ProAgil.Domain.Models;

namespace ProAgil.Application.Services
{
    public class LoteService : ILoteService
    {
        private readonly ILotesRepository _lotesRepository;
        private readonly IMapper _mapper;
        public LoteService(ILotesRepository lotesRepository, IMapper mapper)
        {
            _lotesRepository = lotesRepository;
            _mapper = mapper;
        }

        public async Task ExcluirLotes(LoteViewModel[] lotes)
        {
            var lotesMap = _mapper.Map<Lote[]>(lotes);
            _lotesRepository.ExcluirVarios(lotesMap);
            await _lotesRepository.Commitar();
        }
  }
}