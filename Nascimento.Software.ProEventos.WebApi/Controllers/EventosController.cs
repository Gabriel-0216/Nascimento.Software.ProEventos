using Application.Commands.Requests;
using Application.Queries.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Nascimento.Software.ProEventos.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventosController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IMediator _mediator;

    public EventosController(IMediator mediator, ILogger logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get
    ([FromQuery] int skip = 0, int take = 25, bool incluirPalestrantes = false, bool incluirLotes = false,
        bool incluirRedeSocial = false)
    {
        try
        {
            var query = new ListarEventosQuery(incluirPalestrantes, incluirLotes, incluirRedeSocial);
            return Ok(await _mediator.Send(query));
        }
        catch (SqlException ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AdicionarEventoRequest request)
    {
        try
        {
            var response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }
        catch (SqlException ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] EditarEventoRequest request)
    {
        try
        {
            var response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }
        catch (SqlException ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost]
    [Route("adicionar-lote")]
    public async Task<IActionResult> AdicionarLote([FromBody] AdicionarLoteEventoRequest eventoLoteDto)
    {
        try
        {
            var response = await _mediator.Send(eventoLoteDto);
            return response.Success ? Ok(response) : BadRequest(response);
        }
        catch (SqlException exception)
        {
            _logger.LogError(exception.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost]
    [Route("adicionar-palestrante-evento")]
    public async Task<IActionResult> AdicionarPalestranteEvento([FromBody] AdicionarPalestranteEventoRequest request)
    {
        try
        {
            var response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }
        catch (SqlException exception)
        {
            _logger.LogError(exception.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}