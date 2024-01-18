using JobApplicationTracker.Application.UseCases.JobApplications.Common;
using JobApplicationTracker.Application.UseCases.JobApplications.CreateJobApplication;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Application.UseCases.JobApplications.GetJobApplication
{
    public class GetJobApplicationInput : IRequest<JobApplicationCommonOutput>
    {
        public Guid Id { get; set; }
    }
}
