using MediatR;

namespace Application.Mediator.Journal
{
    public class GetJournalSingleRequest: IRequest<Domain.Entities.Journal>
    {
        public Guid Id { get; set; }
    }
}
