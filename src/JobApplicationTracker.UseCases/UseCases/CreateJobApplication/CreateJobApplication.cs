using JobApplicationTracker.Application.Builders.JobApplicationDTOBuilders;
using JobApplicationTracker.Application.Interfaces;
using JobApplicationTracker.Domain.Entity;

namespace JobApplicationTracker.Application.UseCases.CreateJobApplication
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
        public async Task<CreateJobApplicationOutput> Create(CreateJobApplicationInput createJobApplicationInput)
        {
            var jobApplication = new JobApplication(createJobApplicationInput.Name, createJobApplicationInput.Description,createJobApplicationInput.Company, createJobApplicationInput.Location, createJobApplicationInput.Notes);
            await _jobApplicationRepository.InsertAsync(jobApplication);
            await _unitOfWork.Commit(CancellationToken.None);
            var output = JobApplicationDirectorBuilder.CreateJobApplicationOutputBuilder(jobApplication);
            return output;
        }

        public async Task<CreateJobApplicationOutput> GetById(Guid id)
        {
            var result = await _jobApplicationRepository.GetByIdAsync(id);
            var output = JobApplicationDirectorBuilder.CreateJobApplicationOutputBuilder(result);
            return output;
        }
    }
}
