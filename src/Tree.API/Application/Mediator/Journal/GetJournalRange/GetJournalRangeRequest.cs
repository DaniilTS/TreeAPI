using Application.DTO;
using Domain;
using MediatR;

namespace Application.Mediator.Journal
{
    public class GetJournalRangeRequest: IRequest<List<Domain.Entities.Journal>>
    {
        public DataFilter DataFilter { get; set; }

        public GetJournalRangeRequest(int? skip, int? take, FilterDTO filter)
        {
            DataFilter = new DataFilter
            {
                Skip = skip,
                Take = take,
                From = filter.From,
                To = filter.To,
                Search = filter.Search
            };
        }
    }
}
