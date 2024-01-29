namespace JobApplicationTracker.Application.Interfaces.UseCases
{
    public interface IUnitOfWork
    {
        Task Commit(CancellationToken cancellationToken);
    }
}
