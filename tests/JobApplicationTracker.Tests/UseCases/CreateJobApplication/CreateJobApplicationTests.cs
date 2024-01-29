using FluentAssertions;
using JobApplicationTracker.Application.Interfaces.Repositories;
using JobApplicationTracker.Application.Interfaces.UseCases;
using JobApplicationTracker.Domain.Entity;
using JobApplicationTracker.Tests.Entity.JobApplication;
using Moq;
using JobApplicationUseCase = JobApplicationTracker.Application.UseCases.JobApplications.CreateJobApplication;

namespace JobApplicationTracker.Tests.UseCases.CreateJobApplication
{
    [Collection(nameof(JobApplicationFixtureCollection))]
    public class CreateJobApplicationTests
    {
        private readonly JobApplicationFixture _jobApplicationFixture;
        public CreateJobApplicationTests(JobApplicationFixture jobApplicationFixture) => _jobApplicationFixture = jobApplicationFixture;

        [Fact(DisplayName = nameof(CreateJobApplication))]
        public async void CreateJobApplication()
        {
            var repositoryMock = new Mock<IJobApplicationRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var useCase = new JobApplicationUseCase.CreateJobApplication(repositoryMock.Object, unitOfWorkMock.Object);

            var dummyData = _jobApplicationFixture.CreateValidJobApplication();
            var inputDTO = new JobApplicationUseCase.CreateJobApplicationInput(dummyData.Name, dummyData.Description, dummyData.Company, dummyData.Location, dummyData.Notes);

            var result = await useCase.Handle(inputDTO, CancellationToken.None);

            result.Should().NotBeNull();
            result.Id.Should().NotBe(Guid.Empty);
            result.Name.Should().Be(dummyData.Name);
            result.Description.Should().Be(dummyData.Description);
            result.Company.Should().Be(dummyData.Company);
            result.Location.Should().Be(dummyData.Location);
            result.Notes.Should().Be(dummyData.Notes);

            repositoryMock.Verify(x => x.InsertAsync(It.IsAny<JobApplication>()), Times.Once);
            unitOfWorkMock.Verify(x => x.Commit(It.IsAny<CancellationToken>()), Times.Once);

        }
    }
}
