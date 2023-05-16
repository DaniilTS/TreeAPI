using API.Conventions;
using Application.DTO;
using Application.Mediator.Tree;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Represents entire tree API
    /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns your entire tree. If your tree doesn't exist it will be created automatically.
        /// </remarks>
        /// <returns></returns>
        [HttpPost("api.user.tree.get")]
        [ProducesResponseType(typeof(NodeDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetTree([FromQuery] GetTreeOrCreateRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(_mapper.Map<NodeDTO>(result));
        }
    }
}
