using System.Threading.Tasks;
using AutoMapper;
using ProAgil.Application.Interfaces;
using ProAgil.Application.ViewModels;
using ProAgil.Domain.Interfaces;
using ProAgil.Domain.Models;

namespace ProAgil.Application.Services
{
    public class RedeSocialService : IRedeSocialService
    {
        private readonly IRedesSociaisRepository _redesSociaisRepository;
        private readonly IMapper _mapper;
        public RedeSocialService(IRedesSociaisRepository redesSociaisRepository, IMapper mapper)
        {
            _redesSociaisRepository = redesSociaisRepository;
            _mapper = mapper;
        }

        public async Task ExcluirRedesSociais(RedeSocialViewModel[] redesSociais)
        {
            var redesSociaisMap = _mapper.Map<RedeSocial[]>(redesSociais);
            _redesSociaisRepository.DeleteRange(redesSociaisMap);
            await _redesSociaisRepository.SaveChanges();
        }
  }
}