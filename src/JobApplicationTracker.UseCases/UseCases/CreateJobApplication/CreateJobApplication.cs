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

        public async Task<CreateJobApplicationOutput> GetById(Guid id)
        {
            var result = await _jobApplicationRepository.GetByIdAsync(id);
            var output = JobApplicationDirectorBuilder.CreateJobApplicationOutputBuilder(result);
            return output;
        }

        public async Task<CreateJobApplicationOutput> Handle(CreateJobApplicationInput request, CancellationToken cancellationToken)
        {
            var jobApplication = new JobApplication(request.Name, request.Description, request.Company, request.Location, request.Notes);
            await _jobApplicationRepository.InsertAsync(jobApplication);
            await _unitOfWork.Commit(CancellationToken.None);
            var output = JobApplicationDirectorBuilder.CreateJobApplicationOutputBuilder(jobApplication);
            return output;
        }
    }
}
