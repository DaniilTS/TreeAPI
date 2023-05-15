using API.Conventions;
using Application.DTO;
using Application.Mediator.Journal;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [ControllerName("user.journal")]
    public class JournalController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public JournalController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("api.user.journal.getRange")]
        public async Task<ActionResult> GetRange([FromQuery] int? skip, int? take, [FromBody] FilterDTO filter)
        {
            var result = await _mediator.Send(new GetJournalRangeRequest(skip, take, filter));

            return Ok(_mapper.Map<List<JournalDTO>>(result));
        }

        [HttpPost("api.user.journal.getSingle")]
        public async Task<ActionResult> GetSingle([FromQuery] GetJournalSingleRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(_mapper.Map<JournalDTO>(result));
        }
    }
}
