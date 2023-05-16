namespace Application.DTO
{
    public class NodeDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IList<NodeDTO> Children { get; } = new List<NodeDTO>();
    }
}