using Microsoft.AspNetCore.Mvc;
using ZApoioBack.Models;
using ZApoioBack.Service.Interfaces;

namespace ZApoioBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeployController : ControllerBase
    {
        private readonly IDeployService _deployService;

        public DeployController(IDeployService deployService)
        {
            _deployService = deployService;
        }

        [HttpPost("registrar")]
        public IActionResult Registrar([FromBody] Deploy deploy)
        {
            try
            {
                _deployService.RegistrarDeploy(deploy);
                return Ok(new { message = "Deploy registrado com sucesso." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao registrar deploy.", error = ex.Message });
            }
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try
            {
                var lista = _deployService.ListarDeploys();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao buscar deploys.", error = ex.Message });
            }
        }
    }
}
