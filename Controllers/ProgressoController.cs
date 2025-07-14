using Microsoft.AspNetCore.Mvc;
using ZApoioBack.Models;
using ZApoioBack.Service.Interfaces;

namespace ZApoioBack.Controllers
{
    [ApiController]
    [Route("api/zacademy")]
    public class ProgressoController : ControllerBase
    {
        private readonly IProgressoService _service;

        public ProgressoController(IProgressoService service)
        {
            _service = service;
        }

        [HttpPost("progresso")]
        public IActionResult Registrar([FromBody] ProgressoZAcademy progresso)
        {
            try
            {
                _service.Registrar(progresso);
                return Ok(new { message = "Progresso salvo com sucesso." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao salvar progresso.", error = ex.Message });
            }
        }

        [HttpGet("progresso/{usuario}")]
        public IActionResult BuscarPorUsuario(string usuario)
        {
            try
            {
                var lista = _service.BuscarPorUsuario(usuario);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao buscar progresso.", error = ex.Message });
            }
        }
    }
}
