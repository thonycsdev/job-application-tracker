using JobApplication.Infra.Data.EF;
using JobApplicationTracker.IntegrationTests.Common;
using Microsoft.EntityFrameworkCore;
using DomainEntity = JobApplicationTracker.Domain.Entity;


namespace JobApplicationTracker.IntegrationTests.Infra.Data.EF.Repositories
{
    [CollectionDefinition(nameof(JobApplicationRepositoryFixture))]
    public class JobApplicationRepositoryFixtureCollection : ICollectionFixture<JobApplicationRepositoryFixture>
    {
    }
    public class JobApplicationRepositoryFixture : BaseFixture
    {
        public JobApplicationRepositoryFixture() : base()
        {

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
        public string CreateValidJobApplicationName() => Faker.Name.JobTitle();
        public string CreateValidJobApplicationDescription() => Faker.Lorem.Paragraph();
        public string CreateValidJobApplicationCompany() => Faker.Company.CompanyName();
        public string CreateValidJobApplicationLocation() => Faker.Address.City();
        public string CreateValidJobApplicationNotes() => Faker.Lorem.Paragraph();
        public JobApplicationDbContext GetInMemoryDbContext()
        {
            var dbContextOptions = new DbContextOptionsBuilder<JobApplicationDbContext>().UseInMemoryDatabase("integration-test-db").Options;
            var dbContext = new JobApplicationDbContext(dbContextOptions);
            return dbContext;
        }
    }
}
