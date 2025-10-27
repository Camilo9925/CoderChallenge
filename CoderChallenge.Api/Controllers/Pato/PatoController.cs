using CoderChallenge.Application.Interfaces.Services;
using CoderChallenge.Arguments.Arguments.Pato;
using CoderChallenge.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CoderChallenge.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatoController(IPatoService _service) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<BaseApiResponse<OutputPatoPrimordial>>(StatusCodes.Status200OK)]
    [ProducesResponseType<BaseApiResponse<OutputPatoPrimordial>>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterTodosPatos()
    {
        var resultado = await _service.ObterTodosPatos();
        return resultado.Sucesso ? Ok(resultado) : NotFound(resultado);
    }
    [HttpGet("{id}")]
    [ProducesResponseType<BaseApiResponse<OutputPatoPrimordial>>(StatusCodes.Status200OK)]
    [ProducesResponseType<BaseApiResponse<OutputPatoPrimordial>>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterPatoPorId([FromRoute, Required] string id)
    {
        var resultado = await _service.ObterPatoPorId(id);
        return resultado.Sucesso ? Ok(resultado) : NotFound(resultado);
    }
    [HttpPost]
    [ProducesResponseType<BaseApiResponse<OutputPatoPrimordial>>(StatusCodes.Status201Created)]
    [ProducesResponseType<BaseApiResponse<OutputPatoPrimordial>>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CriarPato([FromBody, Required] InputPatoPrimordial input)
    {
        var resultado = await _service.CriarPato(input);
        return resultado.Sucesso
            ? CreatedAtAction(nameof(ObterPatoPorId), new { id = resultado.Dados.Id }, resultado)
            : BadRequest(resultado);
    }
    [HttpPut("{id}")]
    [ProducesResponseType<BaseApiResponse<OutputPatoPrimordial>>(StatusCodes.Status200OK)]
    [ProducesResponseType<BaseApiResponse<OutputPatoPrimordial>>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AtualizarPato([FromRoute, Required] string id, [FromBody, Required] InputPatoPrimordial input)
    {
        var resultado = await _service.AtualizarPato(id, input);
        return resultado.Sucesso ? Ok(resultado) : NotFound(resultado);
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeletarPato([FromRoute][Required] string id)
    {
        var resultado = await _service.DeletarPato(id);

        if (!resultado.Sucesso)
            return NotFound(resultado);

        return NoContent();
    }
}
