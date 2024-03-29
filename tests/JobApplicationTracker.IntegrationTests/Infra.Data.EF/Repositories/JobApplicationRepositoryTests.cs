﻿using FluentAssertions;
using JobApplication.Infra.Data.EF;
using JobApplication.Infra.Data.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using DomainEntity = JobApplicationTracker.Domain.Entity;
namespace JobApplicationTracker.IntegrationTests.Infra.Data.EF.Repositories
{
    [Collection(nameof(JobApplicationRepositoryFixture))]
    public class JobApplicationRepositoryTests
    {
        private readonly JobApplicationRepositoryFixture _fixture;
        private JobApplicationDbContext _dbContext;
        private DbSet<DomainEntity.JobApplication> _jobApplications;
        public JobApplicationRepositoryTests(JobApplicationRepositoryFixture fixture)
        {
            _fixture = fixture;
            _dbContext = _fixture.GetInMemoryDbContext();
            _jobApplications = _dbContext.Set<DomainEntity.JobApplication>();
        }
        [Fact(DisplayName = nameof(InsertJobApplication))]
        public async void InsertJobApplication()
        {
            var jobApplication = _fixture.CreateValidJobApplication();

            var repository = new JobApplicationRepository(_dbContext);
            await repository.InsertAsync(jobApplication);
            var jobApplicationFromDb = await _jobApplications.FindAsync(jobApplication.Id);
            jobApplicationFromDb.Should().NotBeNull();
            jobApplicationFromDb.Should().BeEquivalentTo(jobApplication);

        }

        [Fact(DisplayName = nameof(GetJobApplicationById))]
        public async void GetJobApplicationById()
        {
            var jobApplication = _fixture.CreateValidJobApplication();

            await _jobApplications.AddAsync(jobApplication);
            await _dbContext.SaveChangesAsync();

            var repository = new JobApplicationRepository(_dbContext);
            var jobApplicationFromDb = await repository.GetByIdAsync(jobApplication.Id);

            jobApplicationFromDb.Should().NotBeNull();
            jobApplicationFromDb.Should().BeEquivalentTo(jobApplication);
        }

        [Fact(DisplayName = nameof(ThrowWhenGetJobApplicationById))]
        public async void ThrowWhenGetJobApplicationById()
        {

            var repository = new JobApplicationRepository(_dbContext);
            var id = Guid.NewGuid();
            var action = async () => await repository.GetByIdAsync(id);
            await action.Should().ThrowAsync<AggregateException>().WithMessage($"Job Application not found with this id: {id}");

        }

        [Fact(DisplayName = nameof(GetAllJobApplication))]
        public async void GetAllJobApplication()
        {
            var jobApplications = new List<DomainEntity.JobApplication>();
            for (int i = 0; i < 100; i++)
                jobApplications.Add(_fixture.CreateValidJobApplication());

            await _jobApplications.AddRangeAsync(jobApplications);
            await _dbContext.SaveChangesAsync();

            var repository = new JobApplicationRepository(_dbContext);
            var jobApplicationsFromDb = await repository.GetAllAsync();

            jobApplicationsFromDb.Should().NotBeNull();
            jobApplicationsFromDb.Should().HaveCount(100);
        }

        [Fact(DisplayName = nameof(UpdateJobApplication))]
        public async void UpdateJobApplication()
        {
            var jobApplicationUpdate = _fixture.CreateValidJobApplication();
            var jobApplication = _fixture.CreateValidJobApplication();
            var defaultDateUpdate = jobApplication.DateUpdated;
            _jobApplications.Add(jobApplication);
            await _dbContext.SaveChangesAsync();

            var repository = new JobApplicationRepository(_dbContext);
            var jobApplicationFromDb = await repository.GetByIdAsync(jobApplication.Id);
            jobApplicationFromDb.Update(jobApplicationUpdate);
            await repository.UpdateAsync(jobApplicationFromDb);

            var jobApplicationUpdatedFromDb = await repository.GetByIdAsync(jobApplication.Id);

            jobApplicationUpdatedFromDb.Should().NotBeNull();
            jobApplicationUpdatedFromDb.Id.Should().Be(jobApplication.Id);

            jobApplicationUpdatedFromDb.Name.Should().Be(jobApplicationUpdate.Name);
            jobApplicationUpdatedFromDb.Description.Should().Be(jobApplicationUpdate.Description);
            jobApplicationUpdatedFromDb.Company.Should().Be(jobApplicationUpdate.Company);
            jobApplicationUpdatedFromDb.Location.Should().Be(jobApplicationUpdate.Location);
            jobApplicationUpdatedFromDb.Notes.Should().Be(jobApplicationUpdate.Notes);
            jobApplicationUpdatedFromDb.Status.Should().Be(jobApplicationUpdate.Status);
            
            jobApplicationUpdatedFromDb.DateApplied.Should().Be(jobApplication.DateApplied);
            
            jobApplicationUpdatedFromDb.DateUpdated.Should().BeAfter(defaultDateUpdate);
            jobApplicationUpdatedFromDb.DateUpdated.Should().BeAfter(jobApplication.DateApplied);


        }

        [Fact(DisplayName = nameof(DeleteJobApplication))]
        public async void DeleteJobApplication()
        {
            var jobApplication = _fixture.CreateValidJobApplication();
            await _jobApplications.AddAsync(jobApplication);
            await  _dbContext.SaveChangesAsync();

            var repository = new JobApplicationRepository(_dbContext);
            var jobApplicationFromDb = await _jobApplications.FindAsync(jobApplication.Id);

            await repository.DeleteAsync(jobApplicationFromDb!);

            var jobApplicationDeletedFromDb = await _jobApplications.FindAsync(jobApplication.Id);

            jobApplicationDeletedFromDb.Should().BeNull();
        }
    }
}
