﻿using JobApplicationTracker.Application.Interfaces.Repositories;
using JobApplicationTracker.Application.Interfaces.UseCases;
using JobApplicationTracker.Tests.Common;
using Moq;
using DomainEntity = JobApplicationTracker.Domain.Entity;
namespace JobApplicationTracker.Tests.Entity.JobApplication
{
    public class JobApplicationFixture : BaseFixture
    {
        public JobApplicationFixture() : base()
        {
            RepositoryMock = new Mock<IJobApplicationRepository>();
            UnitOfWorkMock = new Mock<IUnitOfWork>();
        }

        public DomainEntity.JobApplication CreateValidJobApplication()
        {
            var entityDummyData = new
            {
                Name = CreateValidJobApplicationName(),
                Description = CreateValidJobApplicationDescription(),
                Company = CreateValidJobApplicationCompany(),
                Location = CreateValidJobApplicationLocation(),
                Notes = CreateValidJobApplicationNotes()
            };
            var entity =
                new DomainEntity.JobApplication(
                entityDummyData.Name,
                entityDummyData.Description,
                entityDummyData.Company,
                entityDummyData.Location,
                entityDummyData.Notes
                );
            return entity;
        }
        public Mock<IJobApplicationRepository> RepositoryMock { get; private set; }
        public Mock<IUnitOfWork> UnitOfWorkMock { get; private set; }
        public string CreateValidJobApplicationName() => Faker.Name.JobTitle();
        public string CreateValidJobApplicationDescription() => Faker.Lorem.Paragraph();
        public string CreateValidJobApplicationCompany() => Faker.Company.CompanyName();
        public string CreateValidJobApplicationLocation() => Faker.Address.City();
        public string CreateValidJobApplicationNotes() => Faker.Lorem.Paragraph();

    }

    [CollectionDefinition(nameof(JobApplicationFixtureCollection))]
    public class JobApplicationFixtureCollection : ICollectionFixture<JobApplicationFixture>
    {

    }
}
