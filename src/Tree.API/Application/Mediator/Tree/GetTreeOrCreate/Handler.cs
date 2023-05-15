using Application.Interfaces;
using MediatR;

namespace Application.Mediator.Tree.GetTreeOrCreate
{
    public class Handler : IRequestHandler<GetTreeOrCreateRequest, Domain.Entities.Node>
    {
        private readonly INodeRepository _nodeRepository;

        public Handler(INodeRepository nodeRepository)
        {
            _nodeRepository = nodeRepository;
        }

        public async Task<Domain.Entities.Node> Handle(GetTreeOrCreateRequest request, CancellationToken cancellationToken)
        {
            var tree = await _nodeRepository.GetObject(request.TreeName);
            if (tree != null)
                return tree;

            return await _nodeRepository.Create(request.TreeName);
        }
    }
}
