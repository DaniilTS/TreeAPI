using Domain.Entities;

namespace Application.DTO
{
    public class NodeDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid? ParentId { get; set; }

        public NodeDTO Parent { get; set; }

        public IList<NodeDTO> Childrens { get; } = new List<NodeDTO>();
    }
}