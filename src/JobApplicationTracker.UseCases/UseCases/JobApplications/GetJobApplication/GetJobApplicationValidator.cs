using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Application.UseCases.JobApplications.GetJobApplication
{
    public class GetJobApplicationValidator : AbstractValidator<GetJobApplicationInput>
    {
        public GetJobApplicationValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
