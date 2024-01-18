using JobApplicationTracker.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainEntity = JobApplicationTracker.Domain.Entity;
namespace JobApplicationTracker.Tests.Entity.JobApplication
{
    public class JobApplicationFixture : BaseFixture
    {
        public JobApplicationFixture(): base()
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

    }

    [CollectionDefinition(nameof(JobApplicationFixtureCollection))]
    public class JobApplicationFixtureCollection : ICollectionFixture<JobApplicationFixture>
    {

    }
}
