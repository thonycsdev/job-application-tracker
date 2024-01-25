using JobApplicationTracker.Application.UseCases.JobApplications.DeleteJobApplication;
using JobApplicationTracker.Application.UseCases.JobApplications.GetJobApplication;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Application.Interfaces.UseCases
{
    public interface IDeleteJobApplication : IRequestHandler<DeleteJobApplicationInput, DeleteJobApplicationOutput>
    {
        //Fazer um input diferente para o delete, esse do get job ja esta usando o output do common
    }
}
