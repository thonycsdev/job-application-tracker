using JobApplicationTracker.Application.Interfaces;
using JobApplicationTracker.Tests.Entity.JobApplication;
using JobApplicationUseCase = JobApplicationTracker.Application.UseCases.CreateJobApplication;
using Moq;
using JobApplicationTracker.Application.UseCases.CreateJobApplication;
using FluentAssertions;
using JobApplicationTracker.Domain.Entity;

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
            var inputDTO = new CreateJobApplicationInput(dummyData.Name, dummyData.Description, dummyData.Company, dummyData.Location, dummyData.Notes);

            var result = await useCase.Create(inputDTO);

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

        [Fact(DisplayName = nameof(GetSingleJobApplicationById))]
        public async void GetSingleJobApplicationById()
        {
            var repositoryMock = new Mock<IJobApplicationRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var useCase = new JobApplicationUseCase.CreateJobApplication(repositoryMock.Object, unitOfWorkMock.Object);
            var dummyData = _jobApplicationFixture.CreateValidJobApplication();
            repositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(dummyData);

            var result = await useCase.GetById(Guid.NewGuid());

            result.Should().NotBeNull();
            result.Id.Should().NotBe(Guid.Empty);
            result.Name.Should().Be(dummyData.Name);
            result.Description.Should().Be(dummyData.Description);
            result.Company.Should().Be(dummyData.Company);
            result.Location.Should().Be(dummyData.Location);
            result.Notes.Should().Be(dummyData.Notes);

            repositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<Guid>()), Times.Once);;

        }
    }
}
