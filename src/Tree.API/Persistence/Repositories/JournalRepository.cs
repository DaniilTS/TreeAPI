using Application.Interfaces;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class JournalRepository : IJournalRepository
    {
        private readonly DbContext _dbContext;

        public JournalRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Journal journal)
        {
            await _dbContext.Journals.AddAsync(journal);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Journal>> GetCollection(DataFilter filter)
        {
            IQueryable<Journal> resultQuery = _dbContext.Journals;

            if (filter.From != null)
                resultQuery = resultQuery.Where(x => x.CreatedAt >= filter.From);

            if (filter.To != null)
                resultQuery = resultQuery.Where(x => x.CreatedAt <= filter.To);

            if (filter.Skip != null)
                resultQuery = resultQuery.Skip(filter.Skip.Value);

            if (filter.Take != null)
                resultQuery = resultQuery.Skip(filter.Take.Value);

            if (filter.Search != null)
                resultQuery = resultQuery.Where(x => EF.Functions.Like(x.EventId, $"%{filter.Search}%"));

            return await resultQuery.ToListAsync();
        }

        public async Task<Journal> GetObject(Guid id)
        {
            return await _dbContext.Journals.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
