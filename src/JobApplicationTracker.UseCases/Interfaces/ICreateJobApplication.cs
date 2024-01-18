using JobApplicationTracker.Application.UseCases.CreateJobApplication;

namespace JobApplicationTracker.Application.Interfaces
{
    public interface ICreateJobApplication
    {
        Task<CreateJobApplicationOutput> Create(CreateJobApplicationInput createJobApplicationInput);
        Task<CreateJobApplicationOutput> GetById(Guid id);
    }
}
