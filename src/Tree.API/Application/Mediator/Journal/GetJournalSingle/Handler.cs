using Application.Interfaces;
using MediatR;

namespace Application.Mediator.Journal.GetJournalSingle
{
    public class Handler: IRequestHandler<GetJournalSingleRequest, Domain.Entities.Journal>
    {
        private readonly IJournalRepository _journalRepository;

        public Handler(IJournalRepository journalRepository)
        {
            _journalRepository = journalRepository;
        }

        public async Task<Domain.Entities.Journal> Handle(GetJournalSingleRequest request, CancellationToken cancellationToken)
        {
            return await _journalRepository.GetObject(request.Id);
        }
    }
}