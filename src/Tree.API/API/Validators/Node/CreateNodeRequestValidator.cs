using Application.Mediator.Node;
using FluentValidation;

namespace API.Validators.Node
{
    public class CreateNodeRequestValidator: AbstractValidator<CreateNodeRequest>
    {
        public CreateNodeRequestValidator()
        {
            RuleFor(x => x.TreeName).NotEmpty();
            RuleFor(x => x.ParentNodeId).NotEmpty();
            RuleFor(x => x.NodeName).NotEmpty();
        }
    }
}
