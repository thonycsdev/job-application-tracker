using MediatR;


namespace JobApplicationTracker.Application.UseCases.JobApplications.DeleteJobApplication
{
    public class DeleteJobApplicationInput : IRequest<DeleteJobApplicationOutput>
    {
        public Guid Id { get; set;}
    }
}
