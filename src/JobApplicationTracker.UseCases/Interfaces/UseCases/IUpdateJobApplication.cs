using JobApplicationTracker.Application.UseCases.JobApplications.Common;
using JobApplicationTracker.Application.UseCases.JobApplications.CreateJobApplication;
using JobApplicationTracker.Application.UseCases.JobApplications.UpdateJobApplication;
using MediatR;


namespace JobApplicationTracker.Application.Interfaces.UseCases
{
    public interface IUpdateJobApplication : IRequestHandler<UpdateJobApplicationInput, JobApplicationCommonOutput>
    {
    }
}
