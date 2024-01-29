using FluentValidation;

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
