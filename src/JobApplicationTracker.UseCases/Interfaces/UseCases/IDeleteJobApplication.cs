using JobApplicationTracker.Application.UseCases.JobApplications.DeleteJobApplication;
using MediatR;

namespace JobApplicationTracker.Application.Interfaces.UseCases
{
    public interface IDeleteJobApplication : IRequestHandler<DeleteJobApplicationInput, DeleteJobApplicationOutput>
    {
        //Fazer um input diferente para o delete, esse do get job ja esta usando o output do common
    }
}
