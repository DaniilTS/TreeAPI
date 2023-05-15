namespace Domain.Entities
{
    public class Node
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public Guid? ParentId { get; set; }

        public virtual Node Parent { get; set; }

        public virtual IList<Node> Childrens { get; } = new List<Node>();
    }
}
