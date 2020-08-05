using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.API.Controllers.Base;
using ProAgil.Application.Interfaces;
using ProAgil.Application.ViewModels;

namespace ProAgil.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : BaseController
    {
        private readonly IEventoService _service;
        public EventosController(IEventoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post(EventoViewModel evento)
        {
            try
            {
                var response = await _service.CriarEvento(evento);
                return GetResponse(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, GetCustomMessageError500("criar evento"));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(EventoViewModel evento)
        {
            try
            {
                var eventoEncontrado = await _service.ObterEventoPorId(evento.Id, true);
                if (eventoEncontrado == null) return NotFound();

                var response = await _service.EditarEvento(evento);
                 return GetResponse(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, GetCustomMessageError500("editar evento"));
            }
        }

        [HttpDelete("{eventoId}")]
        public async Task<IActionResult> Delete(int eventoId)
        {
            try
            {
                var eventoEncontrado = await _service.ObterEventoPorId(eventoId, true);
                if (eventoEncontrado == null) return NotFound();

                var response = await _service.ExcluirEvento(eventoEncontrado.Evento);
                return GetResponse(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, GetCustomMessageError500("excluir evento"));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _service.ObterEventos(true);
                return Ok(response.Eventos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, GetCustomMessageError500("listar eventos"));
            }
        }

        [HttpGet("{eventoId}")]
        public async Task<IActionResult> Get(int eventoId)
        {
            try
            {
                var response = await _service.ObterEventoPorId(eventoId, true);
                return Ok(response.Evento);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, GetCustomMessageError500("buscar evento"));
            }
        }

        [HttpGet("obterPorTema/{tema}")]
        public async Task<IActionResult> Get(string tema)
        {
            try
            {
                var response = await _service.ObterEventosPorTema(tema, true);
                return Ok(response.Eventos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, GetCustomMessageError500("buscar evento"));
            }
        }
    }
}
