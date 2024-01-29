using JobApplicationTracker.Application.UseCases.JobApplications.Common;
using JobApplicationTracker.Domain.Enums;
using MediatR;


namespace JobApplicationTracker.Application.UseCases.JobApplications.UpdateJobApplication
{
    public class UpdateJobApplicationInput : IRequest<JobApplicationCommonOutput>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public JobApplicationStatusEnum Status { get; set; }
        public string Notes { get; set; }
        public DateTime DateApplied { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
