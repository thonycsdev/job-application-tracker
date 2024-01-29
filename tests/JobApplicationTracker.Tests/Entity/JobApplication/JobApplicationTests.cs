using FluentAssertions;
using JobApplicationTracker.Domain.Enums;
using JobApplicationTracker.Domain.Exceptions;
using DomainEntity = JobApplicationTracker.Domain.Entity;
namespace JobApplicationTracker.Tests.Entity.JobApplication
{
    [Collection(nameof(JobApplicationFixtureCollection))]
    public class JobApplicationTests
    {
        private readonly JobApplicationFixture _jobApplicationFixture;
        public JobApplicationTests(JobApplicationFixture jobApplicationFixture) => _jobApplicationFixture = jobApplicationFixture;

        [Fact(DisplayName = nameof(InstantiateJobApplication))]
        public void InstantiateJobApplication()
        {
            var jobApplicationData = new
            {
                Name = _jobApplicationFixture.CreateValidJobApplicationName(),
                Description = _jobApplicationFixture.CreateValidJobApplicationDescription(),
                Company = _jobApplicationFixture.CreateValidJobApplicationCompany(),
                Location = _jobApplicationFixture.CreateValidJobApplicationLocation(),
                Notes = _jobApplicationFixture.CreateValidJobApplicationNotes(),
            };

            var jobApplication = new DomainEntity.JobApplication(jobApplicationData.Name, jobApplicationData.Description, jobApplicationData.Company, jobApplicationData.Location, jobApplicationData.Notes);

            jobApplication.Id.Should().NotBe(Guid.Empty);
            jobApplication.Name.Should().Be(jobApplicationData.Name);
            jobApplication.Description.Should().Be(jobApplicationData.Description);
            jobApplication.Company.Should().Be(jobApplicationData.Company);
            jobApplication.Location.Should().Be(jobApplicationData.Location);
            jobApplication.Status.Should().Be(JobApplicationStatusEnum.Applied);
            jobApplication.Notes.Should().Be(jobApplicationData.Notes);
            jobApplication.DateApplied.Should().NotBe(DateTime.MinValue);
            jobApplication.DateUpdated.Should().Be(DateTime.MinValue);

        }

        [Theory(DisplayName = nameof(ThrowError_WhenName_IsInvalid))]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void ThrowError_WhenName_IsInvalid(string name)
        {
            var jobApplicationData = new
            {
                Name = name,
                Description = _jobApplicationFixture.CreateValidJobApplicationDescription(),
                Company = _jobApplicationFixture.CreateValidJobApplicationCompany(),
                Location = _jobApplicationFixture.CreateValidJobApplicationLocation(),
                Notes = _jobApplicationFixture.CreateValidJobApplicationNotes(),
            };

            Action action = () => new DomainEntity.JobApplication(jobApplicationData.Name, jobApplicationData.Description, jobApplicationData.Company, jobApplicationData.Location, jobApplicationData.Notes);
            action.Should().Throw<DomainEntityException>().WithMessage("Name is required");
        }

        [Theory(DisplayName = nameof(ThrowError_WhenDescription_IsInvalid))]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void ThrowError_WhenDescription_IsInvalid(string description)
        {
            var jobApplicationData = new
            {
                Name = _jobApplicationFixture.CreateValidJobApplicationName(),
                Description = description,
                Company = _jobApplicationFixture.CreateValidJobApplicationCompany(),
                Location = _jobApplicationFixture.CreateValidJobApplicationLocation(),
                Notes = _jobApplicationFixture.CreateValidJobApplicationNotes(),
            };

            Action action = () => new DomainEntity.JobApplication(jobApplicationData.Name, jobApplicationData.Description, jobApplicationData.Company, jobApplicationData.Location, jobApplicationData.Notes);
            action.Should().Throw<DomainEntityException>().WithMessage("Description is required");
        }

        [Theory(DisplayName = nameof(ThrowError_WhenCompany_IsInvalid))]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void ThrowError_WhenCompany_IsInvalid(string company)
        {
            var jobApplicationData = new
            {
                Name = _jobApplicationFixture.CreateValidJobApplicationName(),
                Description = _jobApplicationFixture.CreateValidJobApplicationDescription(),
                Company = company,
                Location = _jobApplicationFixture.CreateValidJobApplicationLocation(),
                Notes = _jobApplicationFixture.CreateValidJobApplicationNotes(),
            };

            Action action = () => new DomainEntity.JobApplication(jobApplicationData.Name, jobApplicationData.Description, jobApplicationData.Company, jobApplicationData.Location, jobApplicationData.Notes);
            action.Should().Throw<DomainEntityException>().WithMessage("Company is required");
        }

        [Theory(DisplayName = nameof(ThrowError_WhenLocation_IsInvalid))]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void ThrowError_WhenLocation_IsInvalid(string location)
        {
            var jobApplicationData = new
            {
                Name = _jobApplicationFixture.CreateValidJobApplicationName(),
                Description = _jobApplicationFixture.CreateValidJobApplicationDescription(),
                Company = _jobApplicationFixture.CreateValidJobApplicationCompany(),
                Location = location,
                Notes = _jobApplicationFixture.CreateValidJobApplicationNotes(),
            };

            Action action = () => new DomainEntity.JobApplication(jobApplicationData.Name, jobApplicationData.Description, jobApplicationData.Company, jobApplicationData.Location, jobApplicationData.Notes);
            action.Should().Throw<DomainEntityException>().WithMessage("Location is required");
        }

        [Fact(DisplayName = nameof(ThrowError_WhenLocation_IsInvalid))]
        public void UpdateInformation()
        {
            var jobApplication = _jobApplicationFixture.CreateValidJobApplication();

            var jobApplicationNewData = _jobApplicationFixture.CreateValidJobApplication();

            jobApplication.Update(jobApplicationNewData);

            jobApplication.Name.Should().Be(jobApplicationNewData.Name);
            jobApplication.Description.Should().Be(jobApplicationNewData.Description);
            jobApplication.Company.Should().Be(jobApplicationNewData.Company);
            jobApplication.Location.Should().Be(jobApplicationNewData.Location);
            jobApplication.Notes.Should().Be(jobApplicationNewData.Notes);
            jobApplication.DateUpdated.Should().NotBe(DateTime.MinValue);
            jobApplication.DateUpdated.Should().BeSameDateAs(DateTime.Now);

        }
    }
}
