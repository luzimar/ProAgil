using ProAgil.Application.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAgil.Application.ViewModels
{
    public class EventoViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Local é obrigatório")]
        public string Local { get; set; }
        
        [Required(ErrorMessage = "Data é obrigatória")]
        public string DataEvento { get; set; }

        [Required(ErrorMessage = "Tema é obrigatório")]
        public string Tema { get; set; }

        [Required(ErrorMessage = "Quantidade de pessoas é obrigatória")]
        [Range(20, 120000, ErrorMessage = "Quantidade de pessoas inválida")]
        public int QtdPessoas { get; set; }

        [Required(ErrorMessage = "Imagem do evento é obrigatória")]
        public string ImagemUrl { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório")]
        [Phone(ErrorMessage = "Telefone inválido")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        public List<LoteViewModel> Lotes { get; set; }
        public List<RedeSocialViewModel> RedesSociais { get; set; }
        public List<PalestranteViewModel> Palestrantes { get; set; }
    }
}
