using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Mediator.Node
{
    public class RenameNodeRequest: IRequest
    {
        [BindProperty(Name = "treeName")]
        public string TreeName { get; set; }

        [BindProperty(Name = "nodeId")]
        public Guid NodeId { get; set; }

        [BindProperty(Name = "newNodeName")]
        public string NewNodeName { get; set; }
    }
}