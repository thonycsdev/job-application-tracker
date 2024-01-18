using JobApplicationTracker.Application.UseCases.CreateJobApplication;
using JobApplicationTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Application.Builders.JobApplicationDTOBuilders
{
    public class JobApplicationBuilder : IJobApplicationDTOBuilder
    {
        private CreateJobApplicationOutput _JobApplicationOutput;
        public JobApplicationBuilder()
        {
            _JobApplicationOutput = new CreateJobApplicationOutput();
        }

        public CreateJobApplicationOutput JobApplicationOutput { get => _JobApplicationOutput;}

        public IJobApplicationDTOBuilder WithCompany(string company)
        {
            _JobApplicationOutput.Company = company;
            return this;
        }

        public IJobApplicationDTOBuilder WithDateApplied(DateTime dateApplied)
        {
            _JobApplicationOutput.DateApplied = dateApplied;
            return this;
        }

        public IJobApplicationDTOBuilder WithDateUpdated(DateTime dateUpdated)
        {
            _JobApplicationOutput.DateUpdated = dateUpdated;
            return this;
        }

        public IJobApplicationDTOBuilder WithDescription(string description)
        {
            _JobApplicationOutput.Description = description;
            return this;

        }

        public IJobApplicationDTOBuilder WithId(Guid id)
        {
            _JobApplicationOutput.Id = id;
            return this;

        }

        public IJobApplicationDTOBuilder WithLocation(string location)
        {
            _JobApplicationOutput.Location = location;
            return this;
        }

        public IJobApplicationDTOBuilder WithName(string name)
        {
            _JobApplicationOutput.Name = name;
            return this;
        }

        public IJobApplicationDTOBuilder WithNotes(string notes)
        {
            _JobApplicationOutput.Notes = notes;
            return this;
        }

        public IJobApplicationDTOBuilder WithStatus(JobApplicationStatusEnum status)
        {
            _JobApplicationOutput.Status = status;
            return this;
        }
    }
}
