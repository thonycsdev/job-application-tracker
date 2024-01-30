using FluentAssertions;
using JobApplicationTracker.Application.Interfaces.Repositories;
using JobApplicationTracker.Application.Interfaces.UseCases;
using JobApplicationTracker.Domain.Entity;
using Moq;
using UseCase = JobApplicationTracker.Application.UseCases.JobApplications.DeleteJobApplication;
namespace JobApplicationTracker.Tests.UseCases.DeleteJobApplication
{
    public class DeleteJobApplicationTests
    {
        private readonly Mock<IJobApplicationRepository> _repositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        public DeleteJobApplicationTests()
        {
            _repositoryMock = new Mock<IJobApplicationRepository>();

            _unitOfWorkMock = new Mock<IUnitOfWork>();

        }
        [Fact(DisplayName = nameof(DeleteJobInformationById))]
        public async Task DeleteJobInformationById()
        {
            _repositoryMock.Setup(x => x.DeleteAsync(It.IsAny<JobApplication>())).Returns(Task.CompletedTask);
            var input = new UseCase.DeleteJobApplicationInput { Id = Guid.NewGuid() };

            var useCase = new UseCase.DeleteJobApplication(_repositoryMock.Object, _unitOfWorkMock.Object);
            await useCase.Handle(input, CancellationToken.None);

            _repositoryMock.Verify(x => x.DeleteAsync(It.IsAny<JobApplication>()), Times.Once);
        }

        [Fact(DisplayName = nameof(WhenTheDeleteIsSuccessFullTheResponseShouldContainTrue))]
        public async Task WhenTheDeleteIsSuccessFullTheResponseShouldContainTrue()
        {
            _repositoryMock.Setup(x => x.DeleteAsync(It.IsAny<JobApplication>())).Returns(Task.CompletedTask);
            var input = new UseCase.DeleteJobApplicationInput { Id = Guid.NewGuid() };

            var useCase = new UseCase.DeleteJobApplication(_repositoryMock.Object, _unitOfWorkMock.Object);
            var result = await useCase.Handle(input, CancellationToken.None);
            result.OperationWasSuccessful.Should().BeTrue();

        }
    }
}
