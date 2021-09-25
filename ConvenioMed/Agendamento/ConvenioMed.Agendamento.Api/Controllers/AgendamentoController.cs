using ConvenioMed.Agendamento.Domain.Commands;
using ConvenioMed.Agendamento.Domain.Interfaces.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ConvenioMed.Agendamento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAgendamentoRepository _repo;

        public AgendamentoController(IMediator mediator, IAgendamentoRepository repo)
        {
            _mediator = mediator;
            _repo = repo;
        } 

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _repo.GetAll());
        } 

        [HttpPost]
        public async Task<ActionResult> Post(SolicitarAgendamentoCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _mediator.Send(command));
        } 
    } 
} 
