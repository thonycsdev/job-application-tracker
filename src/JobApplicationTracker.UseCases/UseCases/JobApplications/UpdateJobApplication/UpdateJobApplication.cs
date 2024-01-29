using JobApplicationTracker.Application.Builders.JobApplicationDTOBuilders;
using JobApplicationTracker.Application.Interfaces.Repositories;
using JobApplicationTracker.Application.Interfaces.UseCases;
using JobApplicationTracker.Application.UseCases.JobApplications.Common;
using JobApplicationTracker.Domain.Entity;

namespace JobApplicationTracker.Application.UseCases.JobApplications.UpdateJobApplication
{
    public class UpdateJobApplication : IUpdateJobApplication
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateJobApplication(IJobApplicationRepository jobApplicationRepository, IUnitOfWork unitOfWork)
        {
            _jobApplicationRepository = jobApplicationRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<JobApplicationCommonOutput> Handle(UpdateJobApplicationInput request, CancellationToken cancellationToken)
        {
            var jobApplication = await _jobApplicationRepository.GetByIdAsync(request.Id);

            var jobApplicationRequest = new JobApplication(request.Name, request.Description, request.Company,request.Location, request.Notes);
            
            jobApplication.Update(jobApplicationRequest);
            
            await _jobApplicationRepository.UpdateAsync(jobApplication);
            await _unitOfWork.Commit(cancellationToken);
            
            return JobApplicationDirectorOutputBuilder.CreateJobApplicationOutputBuilder(jobApplication);
        }
    }
}
