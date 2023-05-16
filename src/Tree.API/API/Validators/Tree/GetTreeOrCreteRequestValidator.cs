using Application.Mediator.Tree;
using FluentValidation;

namespace API.Validators.Tree
{
    public class GetTreeOrCreteRequestValidator: AbstractValidator<GetTreeOrCreateRequest>
    {
        public GetTreeOrCreteRequestValidator()
        {
            RuleFor(x => x.TreeName).NotEmpty();
        }
    }
}
