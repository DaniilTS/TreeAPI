using API.Conventions;
using Application.Mediator.Node;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [ControllerName("user.tree.node")]
    public class NodeController : Controller
    {
        private readonly IMediator _mediator;

        public NodeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("api.user.tree.node.create")]
        public async Task<ActionResult> CreateNode([FromQuery] CreateNodeRequest request)
        {
            await _mediator.Send(request);

            return Ok();
        }

        [HttpPost("api.user.tree.node.delete")]
        public async Task<ActionResult> DeleteNode([FromQuery] DeleteNodeRequest request)
        {
            await _mediator.Send(request);

            return Ok();
        }

        [HttpPost("api.user.tree.node.rename")]
        public async Task<ActionResult> RenameNode([FromQuery] RenameNodeRequest request)
        {
            await _mediator.Send(request);

            return Ok();
        }
    }
}