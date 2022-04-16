using Application.Commands.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Nascimento.Software.ProEventos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly IMediator _mediator;
       
        public EventosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /*[HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                return Ok(await _eventoRepo.GetAll(0, 25));
            }
            catch (SqlException ex)
            {
                return StatusCode((StatusCodes.Status500InternalServerError));
            }
        }*/

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AdicionarEventoRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return response.Success ? Ok(response) : BadRequest(response);
            }
            catch (SqlException)
            {
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
            catch (SqlException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }  
        
    }
}
