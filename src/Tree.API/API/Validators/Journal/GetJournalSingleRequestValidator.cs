using Application.Mediator.Journal;
using FluentValidation;

namespace API.Validators.Journal
{
    public class GetJournalSingleRequestValidator: AbstractValidator<GetJournalSingleRequest>
    {
        public GetJournalSingleRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
