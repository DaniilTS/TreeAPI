using API.Conventions;
using Application.DTO;
using Application.Mediator.Tree;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [ControllerName("user.tree")]
    public class TreeController: Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TreeController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("api.user.tree.get")]
        public async Task<ActionResult> GetTree([FromQuery] GetTreeOrCreateRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(_mapper.Map<NodeDTO>(result));
        }
    }
}
