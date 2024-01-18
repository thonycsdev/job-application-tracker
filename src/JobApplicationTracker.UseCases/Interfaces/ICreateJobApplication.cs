using JobApplicationTracker.Application.UseCases.CreateJobApplication;
using MediatR;

namespace JobApplicationTracker.Application.Interfaces
{
    public interface ICreateJobApplication : IRequestHandler<CreateJobApplicationInput, CreateJobApplicationOutput>
    {
        Task<CreateJobApplicationOutput> GetById(Guid id);
    }
}
