using JobApplicationTracker.Application.UseCases.JobApplications.Common;
using JobApplicationTracker.Application.UseCases.JobApplications.CreateJobApplication;
using MediatR;

namespace JobApplicationTracker.Application.Interfaces.UseCases
{
    public interface ICreateJobApplication : IRequestHandler<CreateJobApplicationInput, JobApplicationCommonOutput>
    {
    }
}
