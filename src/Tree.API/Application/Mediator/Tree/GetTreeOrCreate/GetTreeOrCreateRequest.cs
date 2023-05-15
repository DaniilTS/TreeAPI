using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Mediator.Tree
{
    public class GetTreeOrCreateRequest: IRequest<Domain.Entities.Node>
    {
        [BindProperty(Name = "treeName")]
        public string TreeName { get; set; }
    }
}