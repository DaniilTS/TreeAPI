using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Mediator.Node
{
    public class CreateNodeRequest: IRequest
    {
        [BindProperty(Name = "treeName")]
        public string TreeName { get; set; }

        [BindProperty(Name = "parentNodeId")]
        public Guid ParentNodeId { get; set; }

        [BindProperty(Name = "nodeName")]
        public string NodeName { get; set; }
    }
}
