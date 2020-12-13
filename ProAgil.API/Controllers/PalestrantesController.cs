using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain.Interfaces;
using ProAgil.Domain.Models;

namespace ProAgil.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PalestrantesController : ControllerBase
    {
        private readonly IPalestrantesRepository _palestrantesRepository;
        public PalestrantesController(IPalestrantesRepository palestrantesRepository)
        {
            _palestrantesRepository = palestrantesRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Palestrante palestrante)
        {
            try
            {
                await _palestrantesRepository.Adicionar(palestrante);
                if (await _palestrantesRepository.Commitar())
                    return Created($"/api/palestrantes/{palestrante.Id}", palestrante);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao conectar ao banco de dados");
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Palestrante palestrante)
        {
            try
            {
                var palestranteEncontrado = _palestrantesRepository.ObterPalestrantePorId(palestrante.Id);
                if (palestranteEncontrado == null) return NotFound();
                _palestrantesRepository.Atualizar(palestrante);
                if (await _palestrantesRepository.Commitar())
                    return Created($"/api/palestrantes/{palestrante.Id}", palestrante);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao conectar ao banco de dados");
            }
            return BadRequest();
        }

        [HttpDelete("{palestranteId}")]
        public async Task<IActionResult> Delete(int palestranteId)
        {
            try
            {
                var palestranteEncontrado = await _palestrantesRepository.ObterPalestrantePorId(palestranteId);
                if (palestranteEncontrado == null) return NotFound();
                _palestrantesRepository.Excluir(palestranteEncontrado);
                if (await _palestrantesRepository.Commitar())
                    return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao conectar ao banco de dados");
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var palestrante = await _palestrantesRepository.ObterPalestrantes(true);
                return Ok(palestrante);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao conectar ao banco de dados");
            }
        }

        [HttpGet("{palestranteId}")]
        public async Task<IActionResult> Get(int palestranteId)
        {
            try
            {
                var palestrante = await _palestrantesRepository.ObterPalestrantePorId(palestranteId);
                return Ok(palestrante);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao conectar ao banco de dados");
            }
        }

        [HttpGet("obterPorNome/{nome}")]
        public async Task<IActionResult> Get(string nome)
        {
            try
            {
                var palestrantes = await _palestrantesRepository.ObterPalestrantesPorNome(nome);
                return Ok(palestrantes);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao conectar ao banco de dados");
            }
        }
    }
}