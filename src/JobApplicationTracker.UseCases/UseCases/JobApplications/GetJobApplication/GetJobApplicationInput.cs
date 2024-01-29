using JobApplicationTracker.Application.UseCases.JobApplications.Common;
using MediatR;

namespace JobApplicationTracker.Application.UseCases.JobApplications.GetJobApplication
{
    public class GetJobApplicationInput : IRequest<JobApplicationCommonOutput>
    {
        public Guid Id { get; set; }
    }
}
