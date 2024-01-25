using JobApplicationTracker.Application.Interfaces.Repositories;
using JobApplicationTracker.Application.Interfaces.UseCases;


namespace JobApplicationTracker.Application.UseCases.JobApplications.DeleteJobApplication
{
    public class DeleteJobApplication : IDeleteJobApplication
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteJobApplication(IJobApplicationRepository repository, IUnitOfWork unitOfWork)
        {
            _jobApplicationRepository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<DeleteJobApplicationOutput> Handle(DeleteJobApplicationInput request, CancellationToken cancellationToken)
        {
            await _jobApplicationRepository.DeleteAsync(request.Id);
            await _unitOfWork.Commit(cancellationToken);
            return new DeleteJobApplicationOutput { OperationWasSuccessful = true };
        }
    }
}
