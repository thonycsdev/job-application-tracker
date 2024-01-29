using JobApplicationTracker.Domain.Enums;
using JobApplicationTracker.Domain.Exceptions;

namespace JobApplicationTracker.Domain.Entity
{
    public class JobApplication
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Company { get; private set; }
        public string Location { get; private set; }
        public JobApplicationStatusEnum Status { get; private set; }
        public string Notes { get; private set; }
        public DateTime DateApplied { get; private set; }
        public DateTime DateUpdated { get; private set; }

        public JobApplication(string name, string description, string company, string location, string? notes = null)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Company = company;
            Location = location;
            Status = JobApplicationStatusEnum.Applied;
            Notes = notes ?? string.Empty;
            DateApplied = DateTime.Now;
            DateUpdated = DateTime.MinValue;

            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new DomainEntityException("Name is required");
            if (string.IsNullOrWhiteSpace(Description))
                throw new DomainEntityException("Description is required");
            if (string.IsNullOrWhiteSpace(Company))
                throw new DomainEntityException("Company is required");
            if (string.IsNullOrWhiteSpace(Location))
                throw new DomainEntityException("Location is required");

        }

        public void Update(JobApplication jobApplicationNewData)
        {
            this.Company = jobApplicationNewData.Company;
            this.Description = jobApplicationNewData.Description;
            this.Location = jobApplicationNewData.Location;
            this.Name = jobApplicationNewData.Name;
            this.Notes = jobApplicationNewData.Notes;
            this.Status = jobApplicationNewData.Status;
            this.DateUpdated = DateTime.Now;
        }
    }
}
