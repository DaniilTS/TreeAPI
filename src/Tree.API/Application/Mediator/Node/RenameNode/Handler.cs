using Application.Helpers;
using Application.Interfaces;
using Domain.Exceptions;
using MediatR;

namespace Application.Mediator.Node.RenameNode
{
    public class Handler : IRequestHandler<RenameNodeRequest>
    {
        private readonly INodeRepository _nodeRepository;

        public Handler(INodeRepository nodeRepository)
        {
            _nodeRepository = nodeRepository;
        }

        public async Task Handle(RenameNodeRequest request, CancellationToken cancellationToken)
        {
            var tree = await _nodeRepository.GetObject(request.TreeName);
            if (tree is null)
                throw new SecureException($"no such a tree with name {request.TreeName}");

            var node = NodeHelper.FindNode(tree, request.NodeId);
            if (node is null)
                throw new SecureException($"no such a node with id {request.NodeId}");

            if (NodeHelper.HasASiblingWithName(node, request.NewNodeName))
                throw new SecureException($"a node with such a name {request.NewNodeName} is already exists in a tree {request.TreeName}");

            node.Name = request.NewNodeName;

            await _nodeRepository.Update(node);
        }
    }
}