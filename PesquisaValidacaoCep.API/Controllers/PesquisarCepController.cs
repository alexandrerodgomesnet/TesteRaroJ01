using Microsoft.AspNetCore.Mvc;
using PesquisaValidacaoCep.API.Shared.Interfaces;
using PesquisaValidacaoCep.API.Shared.Requests;
using System;
using System.Threading.Tasks;

namespace PesquisaValidacaoCep.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PesquisarCepController : ControllerBase
    {
        private readonly IConsultaCepService _service;

        public PesquisarCepController(IConsultaCepService service)
        {
            _service = service;
        }

        [HttpGet("{cep}")]
        public async Task<IActionResult> Pequisar(string cep)
        {
            try
            {
                var request = new ConsultaCepRequest(cep);

                if (!request.Isvalid())
                    return BadRequest(request.ErrorMessage);

                await _service.ObterDadosCep(request);

                if (!_service.Response.IsValid())
                    return BadRequest(_service.Response.ErrorMessage);

                return Ok(_service.Response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu o seguinte erro ao consultar o cep {cep}: {ex.Message}");
            }
        }
    }
}