using JobApplicationTracker.Application.Builders.JobApplicationDTOBuilders;
using JobApplicationTracker.Application.Interfaces.Repositories;
using JobApplicationTracker.Application.Interfaces.UseCases;
using JobApplicationTracker.Application.UseCases.JobApplications.Common;

namespace JobApplicationTracker.Application.UseCases.JobApplications.GetJobApplication
{
    public class GetJobApplication : IGetJobApplication
    {

        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly IUnitOfWork _unitOfWork;
        public GetJobApplication(IJobApplicationRepository jobApplicationRepository, IUnitOfWork unitOfWork)
        {
            _jobApplicationRepository = jobApplicationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<JobApplicationCommonOutput> Handle(GetJobApplicationInput request, CancellationToken cancellationToken)
        {
            var jobApplication = await _jobApplicationRepository.GetByIdAsync(request.Id);
            return JobApplicationDirectorOutputBuilder.CreateJobApplicationOutputBuilder(jobApplication);
        }
    }
}
