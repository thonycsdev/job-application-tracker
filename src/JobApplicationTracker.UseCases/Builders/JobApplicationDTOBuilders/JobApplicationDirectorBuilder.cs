using JobApplicationTracker.Application.UseCases.CreateJobApplication;
using JobApplicationTracker.Domain.Entity;

namespace JobApplicationTracker.Application.Builders.JobApplicationDTOBuilders
{
    public static class JobApplicationDirectorBuilder
    {
        public static CreateJobApplicationOutput CreateJobApplicationOutputBuilder(JobApplication jobApplication)
        {
            var jobApplicationOutputBuilder = new JobApplicationBuilder();
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
