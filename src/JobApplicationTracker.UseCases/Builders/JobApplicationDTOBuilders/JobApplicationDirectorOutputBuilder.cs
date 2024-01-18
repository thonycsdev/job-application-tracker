using JobApplicationTracker.Application.UseCases.JobApplications.Common;
using JobApplicationTracker.Application.UseCases.JobApplications.CreateJobApplication;
using JobApplicationTracker.Domain.Entity;

namespace JobApplicationTracker.Application.Builders.JobApplicationDTOBuilders
{
    public static class JobApplicationDirectorOutputBuilder
    {
        public static JobApplicationCommonOutput CreateJobApplicationOutputBuilder(JobApplication jobApplication)
        {
            var jobApplicationOutputBuilder = new JobApplicationOutputBuilder();
            jobApplicationOutputBuilder.WithId(jobApplication.Id);
            jobApplicationOutputBuilder.WithName(jobApplication.Name);
            jobApplicationOutputBuilder.WithDescription(jobApplication.Description);
            jobApplicationOutputBuilder.WithCompany(jobApplication.Company);
            jobApplicationOutputBuilder.WithLocation(jobApplication.Location);
            jobApplicationOutputBuilder.WithStatus(jobApplication.Status);
            jobApplicationOutputBuilder.WithNotes(jobApplication.Notes);
            jobApplicationOutputBuilder.WithDateApplied(jobApplication.DateApplied);
            jobApplicationOutputBuilder.WithDateUpdated(jobApplication.DateUpdated);

            return jobApplicationOutputBuilder.JobApplicationOutput;

        }
    }
}
