using Application.Mediator.Node;
using FluentValidation;

namespace API.Validators.Node
{
    public class DeleteNodeRequestValidator: AbstractValidator<DeleteNodeRequest>
    {
        public DeleteNodeRequestValidator()
        {
            RuleFor(x => x.TreeName).NotEmpty();
            RuleFor(x => x.NodeId).NotEmpty();
        }
    }
}
