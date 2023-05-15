using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Mediator.Node
{
    public class DeleteNodeRequest: IRequest
    {
        [BindProperty(Name = "treeName")]
        public string TreeName { get; set; }

        [BindProperty(Name = "nodeId")]
        public Guid NodeId { get; set; }
    }
}
