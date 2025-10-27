using CoderChallenge.Application.Interfaces.Services;
using CoderChallenge.Arguments.Arguments.BuscaPato;
using CoderChallenge.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CoderChallenge.Api.Controllers.BuscaPato
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuscaPatoController(IBuscaPatoService _service) : ControllerBase
    {
        [HttpPost("drone/{droneId}")]
        [ProducesResponseType<BaseApiResponse<OutputBuscaPato>>(StatusCodes.Status200OK)]
        [ProducesResponseType<BaseApiResponse<OutputBuscaPato>>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> BuscaPato([FromRoute, Required] string droneId, string? patoId)
        {
            var resultado = await _service.ExecutarBuscaPatoAsync(droneId, patoId);
            if (!resultado.Sucesso)
                return BadRequest(resultado);

            return Ok(resultado);
        }
    }
}