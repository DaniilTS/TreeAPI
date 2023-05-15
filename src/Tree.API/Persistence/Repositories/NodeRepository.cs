using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class NodeRepository : INodeRepository
    {
        private readonly DbContext _dbContext;

        public NodeRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Node> Create(Node node)
        {
            var entity = await _dbContext.Nodes.AddAsync(node);
            await _dbContext.SaveChangesAsync();

            return entity.Entity;
        }

        public async Task<Node> Create(string treeName)
        {
            var entity = await Create(new Node
            {
                Name = treeName,
            });

            return entity;
        }

        public async Task Delete(Node node)
        {
            _dbContext.Nodes.Remove(node);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Node> GetObject(string treeName)
        {
            return await _dbContext.Nodes.FirstOrDefaultAsync(x => x.Name == treeName);
        }

        public async Task Update(Node node)
        {
            _dbContext.Nodes.Update(node);
            await _dbContext.SaveChangesAsync();
        }
    }
}
