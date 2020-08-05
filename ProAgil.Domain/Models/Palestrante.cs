using ProAgil.Domain.Core.Models;
using ProAgil.Domain.ValueObjects;
using System.Collections.Generic;

namespace ProAgil.Domain.Models
{
    public class Palestrante : Entity
    {
        public string Nome { get; private set; }
        public string MiniCurriculo { get; private set; }
        public string ImagemUrl { get; private set; }
        public string Telefone { get; private set; }
        public Email Email { get; private set; }
        public List<RedeSocial> RedesSociais { get; set; }
        public List<PalestranteEvento> PalestrantesEventos { get; set; }

        public Palestrante(string nome, string miniCurriculo, string imagemUrl, string telefone, Email email)
        {
            Nome = nome;
            MiniCurriculo = miniCurriculo;
            ImagemUrl = imagemUrl;
            Telefone = telefone;
            Email = email;
        }

        protected Palestrante()
        { }
    }
}