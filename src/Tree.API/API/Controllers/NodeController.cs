using API.Conventions;
using Application.DTO;
using Application.Mediator.Node;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Represents tree node API
    /// </summary>
    [ApiController]
    [ControllerName("user.tree.node")]
    public class NodeController : Controller
    {
        private readonly IMediator _mediator;

        public NodeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Create a new node in your tree. You must to specify a parent node ID that belongs to your tree. A new node name must be unique across all siblings.
        /// </remarks>
        /// <returns></returns>
        [HttpPost("api.user.tree.node.create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> CreateNode([FromQuery] CreateNodeRequest request)
        {
            await _mediator.Send(request);

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Delete an existing node in your tree. You must specify a node ID that belongs your tree.
        /// </remarks>
        /// <returns></returns>
        [HttpPost("api.user.tree.node.delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteNode([FromQuery] DeleteNodeRequest request)
        {
            await _mediator.Send(request);

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Rename an existing node in your tree. You must specify a node ID that belongs your tree. A new name of the node must be unique across all siblings.
        /// </remarks>
        /// <returns></returns>
        [HttpPost("api.user.tree.node.rename")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> RenameNode([FromQuery] RenameNodeRequest request)
        {
            await _mediator.Send(request);

            return Ok();
        }
    }
}