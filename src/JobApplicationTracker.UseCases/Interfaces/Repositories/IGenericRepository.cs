namespace JobApplicationTracker.Application.Interfaces.Repositories
{
    public interface IGenericRepository<TAggregate>
    {
        Task<TAggregate> GetByIdAsync(Guid id);
        Task<IEnumerable<TAggregate>> GetAllAsync();
        Task InsertAsync(TAggregate aggregate);
        Task UpdateAsync(TAggregate aggregate);
        Task DeleteAsync(Guid aggregateId);
    }
}
