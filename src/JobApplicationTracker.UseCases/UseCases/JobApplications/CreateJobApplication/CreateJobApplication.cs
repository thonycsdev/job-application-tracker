using JobApplicationTracker.Application.Builders.JobApplicationDTOBuilders;
using JobApplicationTracker.Application.Interfaces.Repositories;
using JobApplicationTracker.Application.Interfaces.UseCases;
using JobApplicationTracker.Application.UseCases.JobApplications.Common;
using JobApplicationTracker.Domain.Entity;

namespace JobApplicationTracker.Application.UseCases.JobApplications.CreateJobApplication
{
    public class CreateJobApplication : ICreateJobApplication
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateJobApplication(IJobApplicationRepository jobApplicationRepository, IUnitOfWork unitOfWork)
        {
            _jobApplicationRepository = jobApplicationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<JobApplicationCommonOutput> Handle(CreateJobApplicationInput request, CancellationToken cancellationToken)
        {
            var jobApplication = new JobApplication(request.Name, request.Description, request.Company, request.Location, request.Notes);
            await _jobApplicationRepository.InsertAsync(jobApplication);
            await _unitOfWork.Commit(CancellationToken.None);
            var output = JobApplicationDirectorOutputBuilder.CreateJobApplicationOutputBuilder(jobApplication);
            return output;
        }
    }
}
