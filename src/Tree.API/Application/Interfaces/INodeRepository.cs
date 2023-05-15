using Domain.Entities;

namespace Application.Interfaces
{
    public interface INodeRepository
    {
        Task<Node> GetObject(string treeName);
        Task<Node> Create(Node node);
        Task<Node> Create(string treeName);

        Task Delete(Node node);
        Task Update(Node node);
    }
}