using Application.Mediator.Node;
using FluentValidation;

namespace API.Validators.Node
{
    public class RenameNodeRequestValidator: AbstractValidator<RenameNodeRequest>
    {
        public RenameNodeRequestValidator()
        {
            RuleFor(x => x.TreeName).NotEmpty();
            RuleFor(x => x.NodeId).NotEmpty();
            RuleFor(x => x.NewNodeName).NotEmpty();
        }
    }
}
