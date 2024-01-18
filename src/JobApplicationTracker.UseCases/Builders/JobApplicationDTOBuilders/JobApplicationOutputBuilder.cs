using JobApplicationTracker.Application.UseCases.JobApplications.Common;
using JobApplicationTracker.Domain.Enums;

namespace JobApplicationTracker.Application.Builders.JobApplicationDTOBuilders
{
    public class JobApplicationOutputBuilder : IJobApplicationOutputBuilder
    {
        private JobApplicationCommonOutput _JobApplicationOutput;
        public JobApplicationOutputBuilder()
        {
            _JobApplicationOutput = new JobApplicationCommonOutput();
        }

        public JobApplicationCommonOutput JobApplicationOutput { get => _JobApplicationOutput; }

        public IJobApplicationOutputBuilder WithCompany(string company)
        {
            _JobApplicationOutput.Company = company;
            return this;
        }

        public IJobApplicationOutputBuilder WithDateApplied(DateTime dateApplied)
        {
            _JobApplicationOutput.DateApplied = dateApplied;
            return this;
        }

        public IJobApplicationOutputBuilder WithDateUpdated(DateTime dateUpdated)
        {
            _JobApplicationOutput.DateUpdated = dateUpdated;
            return this;
        }

        public IJobApplicationOutputBuilder WithDescription(string description)
        {
            _JobApplicationOutput.Description = description;
            return this;

        }

        public IJobApplicationOutputBuilder WithId(Guid id)
        {
            _JobApplicationOutput.Id = id;
            return this;

        }

        public IJobApplicationOutputBuilder WithLocation(string location)
        {
            _JobApplicationOutput.Location = location;
            return this;
        }

        public IJobApplicationOutputBuilder WithName(string name)
        {
            _JobApplicationOutput.Name = name;
            return this;
        }

        public IJobApplicationOutputBuilder WithNotes(string notes)
        {
            _JobApplicationOutput.Notes = notes;
            return this;
        }

        public IJobApplicationOutputBuilder WithStatus(JobApplicationStatusEnum status)
        {
            _JobApplicationOutput.Status = status;
            return this;
        }
    }
}
