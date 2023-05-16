using Application.Extensions;
using Application.Interfaces;
using Domain.Exceptions;
using MediatR;

namespace Application.Mediator.Node.DeleteNode
{
    public class Handler : IRequestHandler<DeleteNodeRequest>
    {
        private readonly INodeRepository _nodeRepository;

        public Handler(INodeRepository nodeRepository)
        {
            _nodeRepository = nodeRepository;
        }

        public async Task Handle(DeleteNodeRequest request, CancellationToken cancellationToken)
        {
            var tree = await _nodeRepository.GetObject(request.TreeName);
            if (tree is null)
                throw new SecureException($"no such a tree with name {request.TreeName}");

            var node = tree.FindNode(request.NodeId);
            if (node is null)
                throw new SecureException($"no such a node with id {request.NodeId}");

            await _nodeRepository.Delete(node);
        }
    }
}