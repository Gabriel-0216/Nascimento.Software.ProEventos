using Application.Commands.Requests;
using Application.Queries.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Nascimento.Software.ProEventos.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PalestrantesController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IMediator _mediator;

    public PalestrantesController(IMediator mediator, ILogger logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get
        ([FromQuery] bool incluirRedeSocial = false, bool incluirEventos = false)
    {
        try
        {
            return Ok(await _mediator.Send(new ListarPalestrantesQuery(incluirEventos, incluirRedeSocial)));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AdicionarPalestranteRequest request)
    {
        try
        {
            var response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest(request);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}