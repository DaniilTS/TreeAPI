using Application.Extensions;
using Application.Interfaces;
using Domain.Exceptions;
using MediatR;

namespace Application.Mediator.Node.CreateNode
{
    public class Handler : IRequestHandler<CreateNodeRequest>
    {
        private readonly INodeRepository _nodeRepository;

        public Handler(INodeRepository nodeRepository)
        {
            _nodeRepository = nodeRepository;
        }

        public async Task Handle(CreateNodeRequest request, CancellationToken cancellationToken)
        {
            var tree = await _nodeRepository.GetObject(request.TreeName);
            if (tree is null)
                throw new SecureException($"no such a tree with name {request.TreeName}");

            var parentNode = tree.FindNode(request.ParentNodeId);
            if (parentNode is null)
                throw new SecureException($"no such a node with id {request.ParentNodeId}");

            if(parentNode.HasANodeWithName(request.NodeName))
                throw new SecureException($"a node with such a name {request.NodeName} is already exists in a tree {request.TreeName}");

            await _nodeRepository.Create(new Domain.Entities.Node
            {
                Name = request.NodeName,
                ParentId = parentNode.Id
            });
        }
    }
}