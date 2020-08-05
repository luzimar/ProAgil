using ProAgil.Domain.Core.Models;
using ProAgil.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace ProAgil.Domain.Models
{
    public class Evento : Entity
    {
        public string Local { get; private set; }
        public DateTime DataEvento { get; private set; }
        public string Tema { get; private set; }
        public QuantidadePessoas QtdPessoas { get; private set; }
        public List<Lote> Lotes { get; set; }
        public List<RedeSocial> RedesSociais { get; set; }
        public string ImagemUrl { get; private set; }
        public string Telefone { get; private set; }
        public Email Email { get; private set; }
        public List<PalestranteEvento> PalestrantesEventos { get; set; }

        public Evento(int? id, string local, DateTime dataEvento, string tema, QuantidadePessoas qtdPessoas, string imagemUrl, string telefone, Email email)
        {
            if (id.HasValue)
                Id = id.Value;

            Local = local;
            DataEvento = dataEvento;
            Tema = tema;
            QtdPessoas = qtdPessoas;
            ImagemUrl = imagemUrl;
            Telefone = telefone;
            Email = email;

            AddNotifications(Email, QtdPessoas);
        }

        protected Evento()
        {}
    }
}