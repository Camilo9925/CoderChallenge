using CoderChallenge.Application.Interfaces.Services;
using CoderChallenge.Arguments.Arguments.Drone;
using CoderChallenge.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CoderChallenge.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DroneController(IDroneService _service) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<BaseApiResponse<OutputDrone>>(StatusCodes.Status200OK)]
    [ProducesResponseType<BaseApiResponse<OutputDrone>>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterTodosDrones()
    {
        var resultado = await _service.ObterTodosDrones();
        return resultado.Sucesso ? Ok(resultado) : NotFound(resultado);
    }
    [HttpGet("{id}")]
    [ProducesResponseType<BaseApiResponse<OutputDrone>>(StatusCodes.Status200OK)]
    [ProducesResponseType<BaseApiResponse<OutputDrone>>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterDronePorId([FromRoute, Required]string id)
    {
        var resultado = await _service.ObterDronePorId(id);
        return resultado.Sucesso ? Ok(resultado) : NotFound(resultado);
    }
    [HttpGet("ativos")]
    [ProducesResponseType<BaseApiResponse<OutputDrone>>(StatusCodes.Status200OK)]
    [ProducesResponseType<BaseApiResponse<OutputDrone>>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterDronesAtivos()
    {
        var resultado = await _service.ObterDronesAtivos();
        return resultado.Sucesso ? Ok(resultado) : NotFound(resultado);
    }
    [HttpGet("destruidos")]
    [ProducesResponseType<BaseApiResponse<OutputDrone>>(StatusCodes.Status200OK)]
    [ProducesResponseType<BaseApiResponse<OutputDrone>>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterDronesDestruidos()
    {
        var resultado = await _service.ObterDronesDestruidos();
        return resultado.Sucesso ? Ok(resultado) : NotFound(resultado);
    }
    [HttpPost]
    [ProducesResponseType<BaseApiResponse<OutputDrone>>(StatusCodes.Status201Created)]
    [ProducesResponseType<BaseApiResponse<OutputDrone>>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CriarDrone([FromBody, Required]InputDrone input)
    {
        var resultado = await _service.CriarDrone(input);
        return resultado.Sucesso
            ? CreatedAtAction(nameof(ObterDronePorId), new { id = resultado.Dados.Id }, resultado)
            : BadRequest(resultado);
    }
    [HttpPut("{id}")]
    [ProducesResponseType<BaseApiResponse<OutputDrone>>(StatusCodes.Status200OK)]
    [ProducesResponseType<BaseApiResponse<OutputDrone>>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AtualizarDrone([FromRoute][Required] string id, [FromBody, Required] InputDrone input)
    {
        var resultado = await _service.AtualizarDrone(id, input);
        return resultado.Sucesso
            ? Ok(resultado)
            : BadRequest(resultado);
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeletarDrone([FromRoute, Required]string id)
    {
        var resultado = await _service.DeletarDrone(id);
        return resultado.Sucesso ? NoContent() : NotFound(resultado);
    }    
}