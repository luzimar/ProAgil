using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProAgil.Domain.Models;
using ProAgil.Domain.ValueObjects;
using ProAgil.Test.FakeRepositories;
using System;
using System.Collections.Generic;

namespace ProAgil.Test.Eventos
{
    [TestClass]
    public class EventosTests
    {
        private List<Evento> _eventos;
        private Repository<Evento> _eventoRepository;
        private EventosFakeRepository _repository;

        [TestMethod]
        public void Should_be_able_to_create_an_event()
        {
            //Arrange
            DefineInstances();
            var qtdPessoas = new QuantidadePessoas(15);
            var email = new Email("netcorecg@gmail.com");
            var evento = new Evento(null,
                                    "Campo grande, MS", 
                                    DateTime.Now.AddDays(20), 
                                    ".NET Core", 
                                    qtdPessoas, 
                                    "img3.jpg", 
                                    "6799999999", 
                                    email,
                                    new List<Lote>(),
                                    new List<RedeSocial>());

            //Act
            _repository.Adicionar(evento);
            var salvouComSucesso = _repository.Commitar().Result;

            //Assert
            evento.Id.Should().NotBe(0);
            salvouComSucesso.Should().Be(true);

        }


        private void DefineInstances()
        {
            _eventos =  new List<Evento>();
            _eventoRepository = new Repository<Evento>(_eventos);
            _repository = new EventosFakeRepository(_eventoRepository, _eventos);
        }
    }
}
