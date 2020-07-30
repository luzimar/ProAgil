using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain.Models;
using ProAgil.Repository.Interfaces;

namespace ProAgil.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventosRepository _eventosRepository;
        public EventosController(IEventosRepository eventosRepository)
        {
            _eventosRepository = eventosRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento evento){
         try
         {
            await _eventosRepository.Add(evento);
            if(await _eventosRepository.SaveChanges())
              return Created($"/api/eventos/{evento.Id}", evento);
         }
         catch (System.Exception)
         {
            return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha ao conectar ao banco");
         }
         return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Evento evento){
         try
         {

            var eventoEncontrado = await _eventosRepository.ObterEventoPorId(evento.Id);
            if(eventoEncontrado == null) return NotFound();

            _eventosRepository.Update(evento);
            if(await _eventosRepository.SaveChanges())
              return Created($"/api/eventos/{evento.Id}", evento);
         }
         catch (System.Exception)
         {
            return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha ao conectar ao banco");
         }
         return BadRequest();
        }

        [HttpDelete("{eventoId}")]
        public async Task<IActionResult> Delete(int eventoId){
         try
         {
            var eventoEncontrado = await _eventosRepository.ObterEventoPorId(eventoId);
            if(eventoEncontrado == null) return NotFound();

            _eventosRepository.Delete(eventoEncontrado);
            if(await _eventosRepository.SaveChanges())
              return Ok();
         }
         catch (System.Exception)
         {
            return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha ao conectar ao banco");
         }
         return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
          try
          {
            var eventos = await _eventosRepository.ObterEventos(true);
            return Ok(eventos);
          }
          catch (System.Exception)
          {
            return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha ao conectar ao banco");
          }
        }

        [HttpGet("{eventoId}")]
        public async Task<IActionResult> Get(int eventoId)
        {
          try
          {
            var evento = await _eventosRepository.ObterEventoPorId(eventoId, true);
            return Ok(evento);
          }
          catch (System.Exception)
          {
            return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha ao conectar ao banco");
          }
        }

        [HttpGet("obterPorTema/{tema}")]
        public async Task<IActionResult> Get(string tema)
        {
          try
          {
            var evento = await _eventosRepository.ObterEventosPorTema(tema, true);
            return Ok(evento);
          }
          catch (System.Exception)
          {
            return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha ao conectar ao banco");
          }
        }
    }
}
