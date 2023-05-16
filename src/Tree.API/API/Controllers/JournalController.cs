using API.Conventions;
using Application.DTO;
using Application.Mediator.Journal;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers
{
    /// <summary>
    /// Represents journal API
    /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Provides the pagination API. Skip means the number of items should be skipped by server. Take means the maximum number items should be returned by server. All fields of the filter are optional.
        /// </remarks>
        /// <returns></returns>
        [HttpPost("api.user.journal.getRange")]
        [ProducesResponseType(typeof(JournalResultDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetRange([FromQuery, Required] int skip, [Required] int take, [FromBody] FilterDTO filter)
        {
            var result = await _mediator.Send(new GetJournalRangeRequest(skip, take, filter));

            var response = new JournalResultDTO
            {
                Skip = skip,
                Count = result.Count,
                Items = _mapper.Map<List<JournalDTO>>(result)
            };

            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns the information about an particular event by ID.
        /// </remarks>
        /// <returns></returns>
        [HttpPost("api.user.journal.getSingle")]
        [ProducesResponseType(typeof(JournalInfoDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetSingle([FromQuery] GetJournalSingleRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(_mapper.Map<JournalInfoDTO>(result));
        }
    }
}
