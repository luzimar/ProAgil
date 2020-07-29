using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProAgil.API.Data;
using ProAgil.API.Models;

namespace ProAgil.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly ILogger<EventosController> _logger;
        private readonly DataContext _context;

        public EventosController(ILogger<EventosController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento evento){
         try
         {
            await _context.Eventos.AddAsync(evento);
            await _context.SaveChangesAsync();
            return Ok("Evento criado com sucesso!");
         }
         catch (System.Exception)
         {
            return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha ao conectar ao banco");
         }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
          try
          {
            var eventos = await _context.Eventos.ToListAsync();
            return Ok(eventos);
          }
          catch (System.Exception)
          {
            return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha ao conectar ao banco");
          }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
          try
          {
            var evento = await _context.Eventos.FirstOrDefaultAsync(x => x.EventoId == id);
            return Ok(evento);
          }
          catch (System.Exception)
          {
            return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha ao conectar ao banco");
          }
        }
    }
}
