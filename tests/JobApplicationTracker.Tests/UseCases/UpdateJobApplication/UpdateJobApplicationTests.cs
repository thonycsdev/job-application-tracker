
using FluentAssertions;
using JobApplicationTracker.Application.UseCases.JobApplications.UpdateJobApplication;
using JobApplicationTracker.Domain.Entity;
using JobApplicationTracker.Domain.Enums;
using JobApplicationTracker.Tests.Entity.JobApplication;
using Moq;
using UseCase = JobApplicationTracker.Application.UseCases.JobApplications.UpdateJobApplication;

namespace JobApplicationTracker.Tests.UseCases.UpdateJobApplication
{
    [Collection(nameof(JobApplicationFixtureCollection))]
    public class UpdateJobApplicationTests
    {
        private readonly JobApplicationFixture _fixture;
        public UpdateJobApplicationTests(JobApplicationFixture jobApplicationFixture) => _fixture = jobApplicationFixture;

        [Fact(DisplayName = "UpdateJobApplication")]
        public async Task UpdateJobApplication()
        {
            var repositoryMock = _fixture.RepositoryMock;
            var unitOfWorkMock = _fixture.UnitOfWorkMock;
            var entity = _fixture.CreateValidJobApplication();
            var requestInput = new UpdateJobApplicationInput
            {
                Id = Guid.NewGuid(),
                Name = _fixture.CreateValidJobApplicationName(),
                Description = _fixture.CreateValidJobApplicationDescription(),
                Company = _fixture.CreateValidJobApplicationCompany(),
                Location = _fixture.CreateValidJobApplicationLocation(),
                Notes = _fixture.CreateValidJobApplicationNotes(),
                Status = JobApplicationStatusEnum.Applied,
            };
            repositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(entity);
            repositoryMock.Setup(x => x.UpdateAsync(It.IsAny<JobApplication>()));

            var useCase = new UseCase.UpdateJobApplication(repositoryMock.Object, unitOfWorkMock.Object);
            await useCase.Handle(requestInput, CancellationToken.None);

            repositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<Guid>()), Times.Once);
            repositoryMock.Verify(x => x.UpdateAsync(It.IsAny<JobApplication>()), Times.Once);
            unitOfWorkMock.Verify(x => x.Commit(It.IsAny<CancellationToken>()), Times.Once);
        }

    }
}
