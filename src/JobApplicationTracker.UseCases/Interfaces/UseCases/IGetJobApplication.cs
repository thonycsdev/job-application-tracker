using JobApplicationTracker.Application.UseCases.JobApplications.Common;
using JobApplicationTracker.Application.UseCases.JobApplications.GetJobApplication;
using MediatR;

namespace JobApplicationTracker.Application.Interfaces.UseCases
{
    public interface IGetJobApplication : IRequestHandler<GetJobApplicationInput, JobApplicationCommonOutput>
    {
    }
}
