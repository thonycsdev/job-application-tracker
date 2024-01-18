using FluentAssertions;
using JobApplicationTracker.Application.Exceptions;
using JobApplicationTracker.Application.Interfaces.Repositories;
using JobApplicationTracker.Application.Interfaces.UseCases;
using JobApplicationTracker.Application.UseCases.JobApplications.GetJobApplication;
using JobApplicationTracker.Domain.Entity;
using JobApplicationTracker.Domain.Exceptions;
using JobApplicationTracker.Tests.Entity.JobApplication;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Tests.UseCases.GetCategory
{
    [Collection(nameof(JobApplicationFixtureCollection))]
    public class GetJobApplicationTests
    {
        private readonly JobApplicationFixture _fixture;
        public GetJobApplicationTests(JobApplicationFixture jobApplicationFixture)
        {
            _fixture = jobApplicationFixture;
        }
        [Fact(DisplayName = nameof(GetSingleJobApplicationById))]
        public async void GetSingleJobApplicationById()
        {
            var repositoryMock = new Mock<IJobApplicationRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var dummyData = _fixture.CreateValidJobApplication();

            var useCase = new GetJobApplication(repositoryMock.Object, unitOfWorkMock.Object);
            repositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(dummyData);

            var input = new GetJobApplicationInput();
            var result = await useCase.Handle(input,CancellationToken.None);

            result.Should().NotBeNull();
            result.Id.Should().NotBe(Guid.Empty);
            result.Name.Should().Be(dummyData.Name);
            result.Description.Should().Be(dummyData.Description);
            result.Company.Should().Be(dummyData.Company);
            result.Location.Should().Be(dummyData.Location);
            result.Notes.Should().Be(dummyData.Notes);

            repositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<Guid>()), Times.Once); ;

        }

        [Fact(DisplayName = nameof(ShouldThrowAnErrorWhenNoJobApplicationWasFoundWithThisID))]
        public async void ShouldThrowAnErrorWhenNoJobApplicationWasFoundWithThisID()
        {
            var repositoryMock = new Mock<IJobApplicationRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var inputGuid = Guid.NewGuid();
            var useCase = new GetJobApplication(repositoryMock.Object, unitOfWorkMock.Object);
            repositoryMock.Setup(x => x.GetByIdAsync(inputGuid)).ThrowsAsync(new NotFoundException($"Job Application with id: {inputGuid} was not found"));

            var input = new GetJobApplicationInput
            {
                Id = inputGuid,
            };

            var action = async () => await useCase.Handle(input, CancellationToken.None);
            await action.Should().ThrowAsync<NotFoundException>().WithMessage($"Job Application with id: {inputGuid} was not found");


        }
        [Fact(DisplayName = nameof(WhenPassedAValidGuidTheResultMustBeValid))]
        public void WhenPassedAValidGuidTheResultMustBeValid()
        {
            var validInput = new GetJobApplicationInput
            {
                Id = Guid.NewGuid(),
            };

            var validator = new GetJobApplicationValidator();
            var result = validator.Validate(validInput);
            result.Should().NotBeNull();
            result.IsValid.Should().BeTrue();
            result.Errors.Should().HaveCount(0);
        }
    }
}
