using ProAgil.Application.ViewModels.Base;
using System.Collections.Generic;

namespace ProAgil.Application.ViewModels
{
    public class PalestranteViewModel : BaseViewModel
    {
        public string Nome { get; private set; }
        public string MiniCurriculo { get; private set; }
        public string ImagemUrl { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public List<RedeSocialViewModel> RedesSociais { get; set; }
        public List<EventoViewModel> Eventos { get; set; }
    }
}
