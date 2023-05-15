using Domain;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IJournalRepository
    {
        Task Create(Journal journal);

        Task<Journal> GetObject(Guid id);

        Task<List<Journal>> GetCollection(DataFilter filter);
    }
}