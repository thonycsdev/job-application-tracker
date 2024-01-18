using JobApplicationTracker.Application.UseCases.JobApplications.Common;
using JobApplicationTracker.Application.UseCases.JobApplications.CreateJobApplication;
using JobApplicationTracker.Application.UseCases.JobApplications.GetJobApplication;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Application.Interfaces.UseCases
{
    public interface IGetJobApplication : IRequestHandler<GetJobApplicationInput, JobApplicationCommonOutput>
    {
    }
}
