using Application.DTO;
using FluentValidation;

namespace API.Validators.Journal
{
    public class FilterDTOValidator: AbstractValidator<FilterDTO>
    {
        public FilterDTOValidator()
        {
            RuleFor(x => x.From).LessThan(x => x.To).When(x => x.From != null && x.To != null);
            RuleFor(x => x.To).GreaterThan(x => x.From).When(x => x.From != null && x.To != null);
        }
    }
}
