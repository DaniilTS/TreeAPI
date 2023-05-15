using Application.Interfaces;
using MediatR;

namespace Application.Mediator.Journal.GetJournalRange
{
    public class Handler : IRequestHandler<GetJournalRangeRequest, List<Domain.Entities.Journal>>
    {
        private readonly IJournalRepository _journalRepository;

        public Handler(IJournalRepository journalRepository)
        {
            _journalRepository = journalRepository;
        }

        public async Task<List<Domain.Entities.Journal>> Handle(GetJournalRangeRequest request, CancellationToken cancellationToken)
        {
            return await _journalRepository.GetCollection(request.DataFilter);
        }
    }
}
